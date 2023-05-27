library IEEE;
use IEEE.STD_LOGIC_1164.ALL;
use IEEE.STD_LOGIC_ARITH.ALL;
use IEEE.STD_LOGIC_UNSIGNED.ALL;

entity ALU is
	port( A, B: IN STD_LOGIC_VECTOR (3 downto 0);
	C: IN STD_LOGIC_VECTOR (1 downto 0);
	R: OUT STD_LOGIC_VECTOR (7 downto 0));
end ALU;

architecture Behavioral of ALU is
begin
	with C SELECT
	R <= A*B when "00",
	("0000" & A) + ("0000" & B) when "01",
	("0000" & A) AND ("0000" & B) when "10",(
	"0000" & A) OR ("0000" & B) when others;
end Behavioral;