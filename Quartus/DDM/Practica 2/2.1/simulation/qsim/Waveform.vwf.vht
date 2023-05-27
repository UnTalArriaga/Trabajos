-- Copyright (C) 2020  Intel Corporation. All rights reserved.
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
-- Generated on "08/31/2022 15:52:55"
                                                             
-- Vhdl Test Bench(with test vectors) for design  :          CONTROLENTRADA
-- 
-- Simulation tool : 3rd Party
-- 

LIBRARY ieee;                                               
USE ieee.std_logic_1164.all;                                

ENTITY CONTROLENTRADA_vhd_vec_tst IS
END CONTROLENTRADA_vhd_vec_tst;
ARCHITECTURE CONTROLENTRADA_arch OF CONTROLENTRADA_vhd_vec_tst IS
-- constants                                                 
-- signals                                                   
SIGNAL A : STD_LOGIC_VECTOR(2 DOWNTO 0);
SIGNAL L : STD_LOGIC_VECTOR(2 DOWNTO 0);
COMPONENT CONTROLENTRADA
	PORT (
	A : IN STD_LOGIC_VECTOR(2 DOWNTO 0);
	L : BUFFER STD_LOGIC_VECTOR(2 DOWNTO 0)
	);
END COMPONENT;
BEGIN
	i1 : CONTROLENTRADA
	PORT MAP (
-- list connections between master ports and signals
	A => A,
	L => L
	);
-- A[2]
t_prcs_A_2: PROCESS
BEGIN
	A(2) <= '1';
	WAIT FOR 120000 ps;
	A(2) <= '0';
	WAIT FOR 320000 ps;
	A(2) <= '1';
	WAIT FOR 120000 ps;
	A(2) <= '0';
WAIT;
END PROCESS t_prcs_A_2;
-- A[1]
t_prcs_A_1: PROCESS
BEGIN
	A(1) <= '0';
	WAIT FOR 160000 ps;
	A(1) <= '1';
	WAIT FOR 120000 ps;
	A(1) <= '0';
	WAIT FOR 160000 ps;
	A(1) <= '1';
	WAIT FOR 120000 ps;
	A(1) <= '0';
WAIT;
END PROCESS t_prcs_A_1;
-- A[0]
t_prcs_A_0: PROCESS
BEGIN
	A(0) <= '0';
	WAIT FOR 340000 ps;
	A(0) <= '1';
	WAIT FOR 80000 ps;
	A(0) <= '0';
WAIT;
END PROCESS t_prcs_A_0;
END CONTROLENTRADA_arch;
