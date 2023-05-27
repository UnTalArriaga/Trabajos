library IEEE;
use IEEE.STD_LOGIC_1164.ALL;
use IEEE.STD_LOGIC_ARITH.ALL;
use IEEE.STD_LOGIC_UNSIGNED.ALL;

entity tabla is
	port (A:in STD_LOGIC_VECTOR (2 downto 0);
	L:out STD_LOGIC_VECTOR(6 downto 0));
end tabla;

architecture Behavioral of tabla is
begin
	with A select
	L<="1000000" when "000",
	"1000110" when "001",
	"0000110" when "010",
	"0000110" when "011",
	"0010010" when "100",
	"0010010" when "101",
	"0010010" when "110",
	"0010010" when others;
end Behavioral;