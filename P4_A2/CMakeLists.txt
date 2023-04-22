cmake_minimum_required(VERSION 3.16)

# Set the target board
set(YAHAL_BOARD "msp432-launchpad")

# Locate the YAHAL library folder
include(YAHAL_import.cmake)

project(servo)

add_executable(servo
    servo.cpp
)

# Add YAHAL
yahal_add_me(servo)

yahal_add_custom_targets(servo)
yahal_add_extra_outputs(servo)
