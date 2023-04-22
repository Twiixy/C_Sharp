cmake_minimum_required(VERSION 3.16)

# Set the target board
set(YAHAL_BOARD "msp432-launchpad")
set(YAHAL_USE_NANO_SPECS 0)

# Locate the YAHAL library folder
include(YAHAL_import.cmake)

# Set clocks to MCU defaults (all 3MHz)
add_compile_options(-DMCLK_SELECT=DCO  -DMCLK_DIV=DIV1)
add_compile_options(-DSMCLK_SELECT=DCO -DSMCLK_DIV=DIV1)

project(sensor)

add_executable(sensor
    sensor.cpp
)

# Add YAHAL
yahal_add_me(sensor)

yahal_add_custom_targets(sensor)
yahal_add_extra_outputs(sensor)
