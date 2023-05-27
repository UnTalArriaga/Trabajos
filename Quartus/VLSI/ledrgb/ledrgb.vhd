library ieee;
use ieee.std_logic_1164.all;
use ieee.numeric_std.all;
use ieee.std_logic_unsigned.all;

entity ledrgb is 
	port(
		clk: in std_logic; --entrada del reloj
		led: out std_logic_vector(2 downto 0); --salida del led
		suma: in std_logic_vector(8 downto 0); --entrada para cambiar el color
		reset: in std_logic --reset
	);
end ledrgb;

architecture arch of ledrgb is
	signal cnt: unsigned (6 downto 0); --señal auxiliar para contar el 100%
	signal aux1: unsigned (6 downto 0):="1100100"; --señales aux para comparar
	signal aux2: unsigned (6 downto 0):="1100100";
	signal aux3: unsigned (6 downto 0):="1100100";

begin
	process(clk,reset,suma) begin
		if reset = '1' then 
			cnt <= (others => '0');
		elsif rising_edge(clk) then
			if cnt = 99 then --cuenta del 0 al 99 y regresa
				cnt <= (others => '0'); 
			else
				cnt <= cnt + 1;
			end if;
		end if;
	end process;

	process (clk) begin
		if suma(0) = '1' then --luz blanca
			aux1 <= "0000000";
			aux2 <= "0000000";
			aux3 <= "0000000";
		elsif suma(1) = '1' then --luz naranja 
			aux1 <= "0110010";
			aux2 <= "1100100";
			aux3 <= "0000000";
		elsif suma(2) = '1' then --luz morada 
			aux1 <= "1100100";
			aux2 <= "0000000";
			aux3 <= "0000000";
		elsif suma(3) = '1' then --luz verde/anaranjado
			aux1 <= "0000000";
			aux2 <= "1100100";
			aux3 <= "0000000";
		elsif suma(4) = '1' then --luz azul cielo 
			aux1 <= "0000000";
			aux2 <= "0000000";
			aux3 <= "1100100";
		elsif suma(5) = '1' then --luz rosa 
			aux1 <= "1100100";
			aux2 <= "0110010";
			aux3 <= "0000000";
		elsif suma(6) = '1' then --luz morado claro 
			aux1 <= "1100100";
			aux2 <= "0000000";
			aux3 <= "0110010";
		elsif suma(7) = '1' then --luz blanco/rosado
			aux1 <= "0110010";
			aux2 <= "0111110";
			aux3 <= "0000000";
		elsif suma(8) = '1' then --luz rosa/morado
			aux1 <= "1100100";
			aux2 <= "1100100";
			aux3 <= "1100100";
		end if;
	end process;

	led(0) <= '1' when (cnt < unsigned(aux1)) else '0'; --salida pwm color verde
	led(1) <= '1' when (cnt < unsigned(aux2)) else '0'; --salida pwm color azul
	led(2) <= '1' when (cnt < unsigned(aux3)) else '0'; --salida pwm color rojo 
end arch;
