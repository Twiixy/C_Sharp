cmake_minimum_required(VERSION 3.16)

# Set the target board
set(YAHAL_BOARD "msp432-launchpad")

# Locate the YAHAL library folder
include(YAHAL_import.cmake)

# Set clocks to MCU defaults (all 3MHz)
add_compile_options(-DMCLK_SELECT=DCO  -DMCLK_DIV=DIV1)
add_compile_options(-DSMCLK_SELECT=DCO -DSMCLK_DIV=DIV1)

project(sound)

add_executable(sound
    sound.cpp
)

# Add YAHAL
yahal_add_me(sound)

yahal_add_custom_targets(sound)
yahal_add_extra_outputs(sound)
