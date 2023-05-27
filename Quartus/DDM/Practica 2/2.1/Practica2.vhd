library IEEE;
use IEEE.STD_LOGIC_1164.ALL;
use IEEE.STD_LOGIC_ARITH.ALL;
use IEEE.STD_LOGIC_UNSIGNED.ALL;

entity CONTROLENTRADA is
	Port (A:in STD_LOGIC_VECTOr (2 DOWNTO 0);
		L: out STD_LOGIC_VECTOR (2 downto 0));
end CONTROLENTRADA;


architecture Behavioral of CONTROLENTRADA is
begin
	with A select
	L <="000" when "000",
		"001" when "001",
		"010" when "010",
		"010" when "011",
		"100" when "100",
		"100" when "101",
		"100" when "110",
		"100" when others;
end behavioral;