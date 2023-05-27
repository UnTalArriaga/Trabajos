library ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;

entity proyectoSTC is 
	port(
		reloj: in std_logic; --este es el reloj
		led: out std_logic_vector(5 downto 0):= "100000"; --los leds 
		reset: in std_logic:= '0'; --el reinicio
		ledEmergencia: out std_logic:='0'; --un led de emergencia
		emergencia: in std_logic; --la entrada por si hay emergencia 
		outDisp: out std_logic_vector(6 downto 0) --salida del display
	);

end proyectoSTC;

architecture Behavioral of proyectoSTC is 
--constantes para la division del tren 
	constant max: integer:= 50000000;
	constant half: integer:= max/2;
	signal count: integer range 0 to max;

--señal de salida del reloj 
	signal seg: std_logic;

--aqui establecemos el tipo de dato del estado
	type estados is (q0,q1);
	signal e_presente: estados;
	signal e_siguiente: estados;

--señales de alto 
	signal alto1: bit:='0';
	signal alto2: bit:='0';

--señal que define la direccion 
	signal este, oeste: std_logic;

--señal para la espera 
	signal cont1: integer:= 0;
	signal cont2: integer:= 0;

--señal que establece la estacion 
	signal estacion: integer:= 1;

	--funcion para mostrar la posicion de los leds 
	function led_Estacion(num_bin: integer) return std_logic_vector is
	begin
		case num_bin is
			when 1 => return "100000";
			when 2 => return "010000";
			when 3 => return "001000";
			when 4 => return "000100";
			when 5 => return "000010";
			when 6 => return "000001";
			when others => return "000000";
		end case;
	end function;

--funcion que muestra en el display la estacion 
	function display_Estacion(num_bin: integer) return std_logic_vector is 
	begin
		case num_bin is
			when 0 => return "1000000"; --0
			when 1 => return "1111001"; --1
			when 2 => return "0100100"; --2
			when 3 => return "0110000"; --3
			when 4 => return "0011001"; --4
			when 5 => return "0010010"; --5
			when 6 => return "0000011"; --6
			when 7 => return "1111000"; --7
			when 8 => return "0000000"; --8
			when 9 => return "0011000"; --9
			when others => return "1111111";
		end case;
	end function;

begin
--divisor de frecuencia
	process(reloj)
		begin
			if (reloj 'event and reloj = '1') then 
				if (count < max ) then count <= count + 1;
				else count <= 1;
				end if;
				if (count <= half) then seg <= '0';
				else seg <= '1';
				end if;
			end if;
	end process;

--proceso
	process (reset, cont1, cont2, emergencia)
		variable tiempo_Espera : integer :=5;
		begin 
			if emergencia= '0' then 
				ledEmergencia <= '1';
				tiempo_Espera:= 25;
			elsif emergencia= '1'then 
				ledEmergencia <= '0';
			end if;
--reseteo de la direccion 
			if reset = '0' then
				este <= '1';
				oeste <= '0';
			end if;
--tiempo de espera 
			if cont1 >= tiempo_Espera then 
				alto1 <= '0';
				tiempo_Espera:= 5;
			else 
				alto1 <= '1';
			end if;
			
			case e_presente is 
				when q0 => --estado 1
					if estacion <= 6 or estacion >= 1 then --revisa que la maquina no se rebase
						e_siguiente <= q1;
						alto1 <= '1';
					else
						e_siguiente <= q0;
					end if;
				when q1 =>
					if estacion >= 6 then --si se llega a la estacion final, el metro cambia de sentido 
						este <= '0';
						oeste <= '1';
						e_siguiente <= q0;
					elsif estacion <= 1 then --si se llega a la estacion inicial, el metro cambia de sentido
						este <= '1';
						oeste <= '0';
						e_siguiente <= q0;
					else
						e_siguiente <= q0;
					end if;
				when others =>
					e_siguiente <= q1;
			end case;
			led <= led_Estacion(estacion); --muestra la estacion de los leds
			outDisp <= display_Estacion(estacion); --muestra en el display la estacion
	end process;

--transicion de estados
	process (seg, alto1, alto2, este, oeste)
	begin
		if seg = '1' and seg 'event then
			e_presente <= e_siguiente;
			if alto1 = '0' then --reinicia el valor de alto1
				cont1 <= 0;
			else
				cont1 <= cont1 + 1;
			end if;

			if este = '1' and alto1 = '0' and oeste = '0' then --aumentamos la estacion
				estacion <= estacion + 1;
			elsif oeste = '1' and alto1 = '0' and este = '0' then --disminuimos la estacion
				estacion <= estacion - 1;
			end if;
			if reset = '0' then --reseteamos la estacion
				estacion <= 1;
			end if;
		end if;
	end process;
end Behavioral;