library IEEE;
use IEEE.std_logic_1164.all;
use IEEE.std_logic_arith.all;
use IEEE.std_logic_unsigned.all;

entity ASM is 
	port (reloj: in std_logic;
			A: in std_logic;
			L: out std_logic_vector (2 downto 0));
end ASM;

architecture Behavioral of ASM is
type estados is (s0,s1,s2,s3,s4);
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
	
	MdE2: process (ep)
	begin
		case ep is
			when s0=>
				L <="000";
				if A='1' then
					es<=s1;
				else
					es<=s4;
				end if;
			when s1=>
				L <="010";
				if A='1' then
					es<=s2;
				else
					es<=s0;
				end if;
			when s2=>
				L <="011";
				if A='1' then
					es<=s3;
				else
					es<=s1;
				end if;
			when s3=>
				L <="101";
				if A='1' then
					es<=s4;
				else
					es<=s2;
				end if;
			when s4=>
				L <="111";
				if A='1' then
					es<=s0;
				else
					es<=s3;
				end if;
		end case;
	end process;
end Behavioral;
		