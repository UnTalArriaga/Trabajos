library IEEE;
use IEEE.std_logic_1164.all;
use IEEE.std_logic_arith.all;
use IEEE.std_logic_unsigned.all;

entity SdP is 
	port (reloj: in std_logic;
			Sensor1: in std_logic;
			Sensor2: in std_logic;
			Led: out std_logic_vector (1 downto 0));
end SdP;

architecture Behavioral of SdP is
type estados is (s0,s1,s2,s3,s4,s5);
signal Ep, es: estados;
signal seg: std_logic;

begin
	
	divisor: process (reloj)
	variable cuenta: std_logic_vector (27 downto 0):=X"0000000";
	begin
		if rising_edge (reloj) then
			if cuenta=X"48009E0" then
				cuenta := X"0000000";
			else
				cuenta:=cuenta+1;
			end if;
		end if;
		seg<=cuenta(24);
	end process;
	
	MdE1:process(seg)
	begin 
		if rising_edge (seg) then
			ep<=es;
		end if;
	end process;
	
	MdE2:process(ep)
	begin
		case ep is
			when s0=>
				Led <="00";
				if Sensor1='1' and Sensor2='0' then
					es<=s1;
				else
					if (Sensor2='1' and Sensor1='0') then
						es<=s5;
					else
						es<=s0;
					end if;
				end if;
			when s1=>
				Led <="10";
				if Sensor1='0' then
					es<=s2;
				else
					es<=s1;
				end if;
			when s2=>
				Led <="11";
					es<=s3;

			when s3=>
				Led <="11";
					es<=s4;

			when s4=>
				Led <="11";
					es<=s0;
			when s5=>
				Led <="01";
				if Sensor2='0' then
					es<=s2;
				else
					es<=s5;
				end if;		
		end case;
	end process;
end Behavioral;
		