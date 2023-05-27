-- Copyright (C) 2019  Intel Corporation. All rights reserved.
-- Your use of Intel Corporation's design tools, logic functions 
-- and other software and tools, and any partner logic 
-- functions, and any output files from any of the foregoing 
-- (including device programming or simulation files), and any 
-- associated documentation or information are expressly subject 
-- to the terms and conditions of the Intel Program License 
-- Subscription Agreement, the Intel Quartus Prime License Agreement,
-- the Intel FPGA IP License Agreement, or other applicable license
-- agreement, including, without limitation, that your use is for
-- the sole purpose of programming logic devices manufactured by
-- Intel and sold by Intel or its authorized distributors.  Please
-- refer to the applicable agreement for further details, at
-- https://fpgasoftware.intel.com/eula.

-- *****************************************************************************
-- This file contains a Vhdl test bench with test vectors .The test vectors     
-- are exported from a vector file in the Quartus Waveform Editor and apply to  
-- the top level entity of the current Quartus project .The user can use this   
-- testbench to simulate his design using a third-party simulation tool .       
-- *****************************************************************************
-- Generated on "12/17/2022 22:05:27"
                                                             
-- Vhdl Test Bench(with test vectors) for design  :          proyectoReloj
-- 
-- Simulation tool : 3rd Party
-- 

LIBRARY ieee;                                               
USE ieee.std_logic_1164.all;                                

ENTITY proyectoReloj_vhd_vec_tst IS
END proyectoReloj_vhd_vec_tst;
ARCHITECTURE proyectoReloj_arch OF proyectoReloj_vhd_vec_tst IS
-- constants                                                 
-- signals                                                   
SIGNAL ajuste : STD_LOGIC;
SIGNAL ajuste_hh : STD_LOGIC;
SIGNAL ajuste_mm : STD_LOGIC;
SIGNAL clk_50Mhz : STD_LOGIC;
SIGNAL hex0 : STD_LOGIC_VECTOR(0 TO 6);
SIGNAL hex1 : STD_LOGIC_VECTOR(0 TO 6);
SIGNAL hex2 : STD_LOGIC_VECTOR(0 TO 6);
SIGNAL hex3 : STD_LOGIC_VECTOR(0 TO 6);
SIGNAL hex4 : STD_LOGIC_VECTOR(0 TO 6);
SIGNAL hex5 : STD_LOGIC_VECTOR(0 TO 6);
SIGNAL reset : STD_LOGIC;
COMPONENT proyectoReloj
	PORT (
	ajuste : IN STD_LOGIC;
	ajuste_hh : IN STD_LOGIC;
	ajuste_mm : IN STD_LOGIC;
	clk_50Mhz : IN STD_LOGIC;
	hex0 : OUT STD_LOGIC_VECTOR(0 TO 6);
	hex1 : OUT STD_LOGIC_VECTOR(0 TO 6);
	hex2 : OUT STD_LOGIC_VECTOR(0 TO 6);
	hex3 : OUT STD_LOGIC_VECTOR(0 TO 6);
	hex4 : OUT STD_LOGIC_VECTOR(0 TO 6);
	hex5 : OUT STD_LOGIC_VECTOR(0 TO 6);
	reset : IN STD_LOGIC
	);
END COMPONENT;
BEGIN
	i1 : proyectoReloj
	PORT MAP (
-- list connections between master ports and signals
	ajuste => ajuste,
	ajuste_hh => ajuste_hh,
	ajuste_mm => ajuste_mm,
	clk_50Mhz => clk_50Mhz,
	hex0 => hex0,
	hex1 => hex1,
	hex2 => hex2,
	hex3 => hex3,
	hex4 => hex4,
	hex5 => hex5,
	reset => reset
	);

-- ajuste
t_prcs_ajuste: PROCESS
BEGIN
	ajuste <= '0';
WAIT;
END PROCESS t_prcs_ajuste;

-- ajuste_hh
t_prcs_ajuste_hh: PROCESS
BEGIN
	ajuste_hh <= '0';
WAIT;
END PROCESS t_prcs_ajuste_hh;

-- ajuste_mm
t_prcs_ajuste_mm: PROCESS
BEGIN
	ajuste_mm <= '0';
WAIT;
END PROCESS t_prcs_ajuste_mm;

-- clk_50Mhz
t_prcs_clk_50Mhz: PROCESS
BEGIN
	clk_50Mhz <= '0';
	WAIT FOR 20000 ps;
	clk_50Mhz <= '1';
	WAIT FOR 20000 ps;
	clk_50Mhz <= '0';
	WAIT FOR 20000 ps;
	clk_50Mhz <= '1';
	WAIT FOR 20000 ps;
	clk_50Mhz <= '0';
	WAIT FOR 20000 ps;
	clk_50Mhz <= '1';
	WAIT FOR 20000 ps;
	clk_50Mhz <= '0';
	WAIT FOR 20000 ps;
	clk_50Mhz <= '1';
	WAIT FOR 20000 ps;
	clk_50Mhz <= '0';
	WAIT FOR 20000 ps;
	clk_50Mhz <= '1';
	WAIT FOR 20000 ps;
	clk_50Mhz <= '0';
	WAIT FOR 20000 ps;
	clk_50Mhz <= '1';
	WAIT FOR 20000 ps;
	clk_50Mhz <= '0';
WAIT;
END PROCESS t_prcs_clk_50Mhz;

-- reset
t_prcs_reset: PROCESS
BEGIN
	reset <= '0';
WAIT;
END PROCESS t_prcs_reset;
END proyectoReloj_arch;
