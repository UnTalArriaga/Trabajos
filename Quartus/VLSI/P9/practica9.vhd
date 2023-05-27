library ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_arith.all;
use ieee.std_logic_unsigned.all;

entity rx is
	port(clk: in std_logic;
			swt: in std_logic_vector(3 downto 0);
			display1: buffer std_logic_vector (6 downto 0);-- valores para el display 
			display2: buffer std_logic_vector (6 downto 0);
			display3: buffer std_logic_vector (6 downto 0);
			display4: buffer std_logic_vector (6 downto 0);
			display5: buffer std_logic_vector (6 downto 0);
			led1: out std_logic; -- 8 leds de los cuales usaremos solo 4
			led2: out std_logic;
			led3: out std_logic;
			led4: out std_logic;
			led5: out std_logic;
			led6: out std_logic;
			led7: out std_logic;
			led8: out std_logic;
			rx_wire: in std_logic --receptor
			);
end entity;

architecture behavioral of rx is
component pwm is --arquitectura del receptor de comunicacion serial
	port(reloj_pwm: in std_logic;
			d: in std_logic_vector (7 downto 0);
			s: out std_logic);
end component;

component divisor is
	generic(n: integer:= 24);
	port(reloj: in std_logic;
		  div_reloj: out std_logic);
end component;

signal buff: std_logic_vector(9 downto 0);
signal flag: std_logic:= '0';
signal chek: std_logic:= '1';
signal pre: integer range 0 to 5208: = 0;
signal indice: integer range 0 to 9:= 0;
signal pre_val: integer range 0 to 41600;
signal baud: std_logic_vector(2 downto 0);
signal relojpwm: std_logic;
signal relojciclo: std_logic;
signal leds: std_logic_vector(7 downto 0);
signal contador1: std_logic_vector(3 downto 0):= "0000";
signal contador2: std_logic_vector(3 downto 0):= "0000";
signal contador3: std_logic_vector(3 downto 0):= "0000";
signal contador4: std_logic_vector(3 downto 0):= "0000";
signal contador5: std_logic_vector(3 downto 0):= "0000";
signal a1: std_logic_vector(7 downto 0):= x"00";
signal a2: std_logic_vector(7 downto 0):= x"20";
signal a3: std_logic_vector(7 downto 0):= x"60";
signal a4: std_logic_vector(7 downto 0):= x"F8";
signal a5: std_logic_vector(7 downto 0):= x"00";
signal a6: std_logic_vector(7 downto 0):= x"20";
signal a7: std_logic_vector(7 downto 0):= x"60";
signal a8: std_logic_vector(7 downto 0):= x"F8";

begin
	n1: divisor generic map(10) port map(clk, relojpwm);
	n2: divisor generic map(23) port map(clk, relojciclo);
	p1: pwm port map(relojpwm, a1, led1);
	p2: pwm port map(relojpwm, a2, led2);
	p3: pwm port map(relojpwm, a3, led3);
	p4: pwm port map(relojpwm, a4, led4);
	p5: pwm port map(relojpwm, a5, led5);
	p6: pwm port map(relojpwm, a6, led6);
	p7: pwm port map(relojpwm, a7, led7);
	p8: pwm port map(relojpwm, a8, led8);

	rx_dato: process(clk)
	variable cuenta: integer range 0 to 255:= 0;

	begin 
		if(flag = '0' and clk = '1') then 
			flaj <= '1';
			indice <= 0;
			pre <= 0;
		end if;
		if(flag = '1') then 
			buff(indice) <= rx_wire;
		if(pre < pre_val) then 
			pre <= pre + 1;
		else
			pre <= 0;
		end if;
		if (pre = pre_val/2) then 
			if(indice < 9) then 
				indice <= indice + 1;
			else
				if(buff(0) = '0' and buff(9) = '1') then
					leds <= buff(8 downto 1)
				else
					leds <= "00000000";
				end if;
				flag <= '0';
			end if;
		end if;
		end if;
		end if;
	end process rx_dato;
	
	baud <= "011";
	with (baud) select 
		pre_val <= 41600 when "000"
			20800 when "001",
			10400 when "010",
			5200 when "011",
			2600 when "100",
			1300 when "101",
			866 when "110",
			432 when others;
			
process(relojciclo, leds)
	begin
		if rising_edge(relojciclo) then 
			if(leds = "00110001") then 
				if swt(0) = '1' then 
					if(chek = '1') then 
						a1 <= a5;
						a2 <= a6;
						a3 <= a7;
						a4 <= a8;
					end if;
					a4 <= a1;
					a3 <= a4;
					a2 <= a3;
					a1 <= a2;
					chek <= '0';
				else
					if(chek = '1') then
						a1 <= a8;
						a2 <= a7;
						a3 <= a6;
						a4 <= a5;
					end if;
					a1 <= a4;
					a2 <= a1;
					a3 <= a2;
					a4 <= a3;
					chek <= '0';
				end if;
			elsif(leds = "00110010") then 
				contador1 <= contador1 + 1;
				contador2 <= contador2 + 1;
				contador3 <= contador3 + 1;
				contador4 <= contador4 + 1;
				contador5 <= contador5 + 1;
			elsif(leds = "00110100") then
				if swt(0) = '1' then a1 <= a8;
				elsif swt(1) = '1' then a1 <= a7;
				elsif swt(2) = '1' then a1 <= a6;
				elsif swt(3) = '1' then a1 <= a5;
				end if;
				chek<= 1;
			end if;
		end if;
end process;

with contador1 select
	display1 <= 
		"1000000" when "0000",
		"1111001" when "0001",
		"1000000" when "0010",
		"1111001" when "0011",
		"1000000" when "0100",
		"1111001" when "0101",
		"1000000" when "0110",
		"1111001" when "0111",
		"1000000" when "1000",
		"1111001" when "1001",
		"1111111" when others;
		
with contador2 select
	display2 <= 
		"1000000" when "0000",
		"1000000" when "0001",
		"1111001" when "0010",
		"1111001" when "0011",
		"1000000" when "0100",
		"1000000" when "0101",
		"1111001" when "0110",
		"1111001" when "0111",
		"1000000" when "1000",
		"1000000" when "1001",
		"1111111" when others;
		
with contador3 select
	display3 <= 
		"1000000" when "0000",
		"1000000" when "0001",
		"1000000" when "0010",
		"1000000" when "0011",
		"1111001" when "0100",
		"1111001" when "0101",
		"1111001" when "0110",
		"1111001" when "0111",
		"1000000" when "1000",
		"1000000" when "1001",
		"1111111" when others;
		
with contador4 select
	display4 <= 
		"1000000" when "0000",
		"1000000" when "0001",
		"1000000" when "0010",
		"1000000" when "0011",
		"1000000" when "0100",
		"1000000" when "0101",
		"1000000" when "0110",
		"1000000" when "0111",
		"1111001" when "1000",
		"1111001" when "1001",
		"1111111" when others;
		
with contador5 select
	display5 <= 
		"1000000" when "0000",
		"1111001" when "0001",
		"0100100" when "0010",
		"0110000" when "0011",
		"0011001" when "0100",
		"0010010" when "0101",
		"0000010" when "0110",
		"1111000" when "0111",
		"0000000" when "1000",
		"0011000" when "1001",
		"1111111" when others;
end process;
end behavioral;		

		