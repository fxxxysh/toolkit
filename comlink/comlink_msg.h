#pragma once

#include "stdint.h"

#pragma pack(push,1)
typedef struct __mavlink_attitude_t {
	uint32_t time_boot_ms; /*< Timestamp (milliseconds since system boot)*/
	float roll; /*< Roll angle (rad, -pi..+pi)*/
	float pitch; /*< Pitch angle (rad, -pi..+pi)*/
	float yaw; /*< Yaw angle (rad, -pi..+pi)*/
	float rollspeed; /*< Roll angular speed (rad/s)*/
	float pitchspeed; /*< Pitch angular speed (rad/s)*/
	float yawspeed; /*< Yaw angular speed (rad/s)*/
} mavlink_attitude_t;
#pragma pack(pop) 