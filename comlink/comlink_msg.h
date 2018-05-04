#pragma once

#include "stdint.h"

#define MAVPACKED( __Declaration__ ) __pragma( pack(push, 1) ) __Declaration__ __pragma( pack(pop) )

MAVPACKED(
	typedef struct __mavlink_att_pos_mocap_t {
	uint64_t time_usec; /*< Timestamp (micros since boot or Unix epoch)*/
	float q[4]; /*< Attitude quaternion (w, x, y, z order, zero-rotation is 1, 0, 0, 0)*/
	float x; /*< X position in meters (NED)*/
	float y; /*< Y position in meters (NED)*/
	float z; /*< Z position in meters (NED)*/
}) mavlink_att_pos_mocap_t;

#define MAVLINK_MSG_ID_ATT_POS_MOCAP 138
MAVPACKED(
	typedef struct __mavlink_altitude_t {
	uint64_t time_usec; /*< Timestamp (micros since boot or Unix epoch)*/
	float altitude_monotonic; /*< This altitude measure is initialized on system boot and monotonic (it is never reset, but represents the local altitude change). The only guarantee on this field is that it will never be reset and is consistent within a flight. The recommended value for this field is the uncorrected barometric altitude at boot time. This altitude will also drift and vary between flights.*/
	float altitude_amsl; /*< This altitude measure is strictly above mean sea level and might be non-monotonic (it might reset on events like GPS lock or when a new QNH value is set). It should be the altitude to which global altitude waypoints are compared to. Note that it is *not* the GPS altitude, however, most GPS modules already output AMSL by default and not the WGS84 altitude.*/
	float altitude_local; /*< This is the local altitude in the local coordinate frame. It is not the altitude above home, but in reference to the coordinate origin (0, 0, 0). It is up-positive.*/
	float altitude_relative; /*< This is the altitude above the home position. It resets on each change of the current home position.*/
	float altitude_terrain; /*< This is the altitude above terrain. It might be fed by a terrain database or an altimeter. Values smaller than -1000 should be interpreted as unknown.*/
	float bottom_clearance; /*< This is not the altitude, but the clear space below the system according to the fused clearance estimate. It generally should max out at the maximum range of e.g. the laser altimeter. It is generally a moving target. A negative value indicates no measurement available.*/
}) mavlink_altitude_t;

#define MAVLINK_MSG_ID_ALTITUDE 141
MAVPACKED(
	typedef struct __mavlink_altitude_t {
	uint64_t time_usec; /*< Timestamp (micros since boot or Unix epoch)*/
	float altitude_monotonic; /*< This altitude measure is initialized on system boot and monotonic (it is never reset, but represents the local altitude change). The only guarantee on this field is that it will never be reset and is consistent within a flight. The recommended value for this field is the uncorrected barometric altitude at boot time. This altitude will also drift and vary between flights.*/
	float altitude_amsl; /*< This altitude measure is strictly above mean sea level and might be non-monotonic (it might reset on events like GPS lock or when a new QNH value is set). It should be the altitude to which global altitude waypoints are compared to. Note that it is *not* the GPS altitude, however, most GPS modules already output AMSL by default and not the WGS84 altitude.*/
	float altitude_local; /*< This is the local altitude in the local coordinate frame. It is not the altitude above home, but in reference to the coordinate origin (0, 0, 0). It is up-positive.*/
	float altitude_relative; /*< This is the altitude above the home position. It resets on each change of the current home position.*/
	float altitude_terrain; /*< This is the altitude above terrain. It might be fed by a terrain database or an altimeter. Values smaller than -1000 should be interpreted as unknown.*/
	float bottom_clearance; /*< This is not the altitude, but the clear space below the system according to the fused clearance estimate. It generally should max out at the maximum range of e.g. the laser altimeter. It is generally a moving target. A negative value indicates no measurement available.*/
}) mavlink_altitude_t;


#define MAVLINK_MSG_ID_PARAM_VALUE 22
MAVPACKED(
	typedef struct __mavlink_param_value_t {
	float param_value; /*< Onboard parameter value*/
	uint16_t param_count; /*< Total number of onboard parameters*/
	uint16_t param_index; /*< Index of this onboard parameter*/
	char param_id[16]; /*< Onboard parameter id, terminated by NULL if the length is less than 16 human-readable chars and WITHOUT null termination (NULL) byte if the length is exactly 16 chars - applications have to provide 16+1 bytes storage if the ID is stored as string*/
	uint8_t param_type; /*< Onboard parameter type: see the MAV_PARAM_TYPE enum for supported data types.*/
}) mavlink_param_value_t;

#define MAVLINK_MSG_ID_PARAM_SET 23
MAVPACKED(
	typedef struct __mavlink_param_set_t {
	float param_value; /*< Onboard parameter value*/
	uint8_t target_system; /*< System ID*/
	uint8_t target_component; /*< Component ID*/
	char param_id[16]; /*< Onboard parameter id, terminated by NULL if the length is less than 16 human-readable chars and WITHOUT null termination (NULL) byte if the length is exactly 16 chars - applications have to provide 16+1 bytes storage if the ID is stored as string*/
	uint8_t param_type; /*< Onboard parameter type: see the MAV_PARAM_TYPE enum for supported data types.*/
}) mavlink_param_set_t;

#define MAVLINK_MSG_ID_RAW_IMU 27
MAVPACKED(
	typedef struct __mavlink_raw_imu_t {
	uint64_t time_usec; /*< Timestamp (microseconds since UNIX epoch or microseconds since system boot)*/
	int16_t xacc; /*< X acceleration (raw)*/
	int16_t yacc; /*< Y acceleration (raw)*/
	int16_t zacc; /*< Z acceleration (raw)*/
	int16_t xgyro; /*< Angular speed around X axis (raw)*/
	int16_t ygyro; /*< Angular speed around Y axis (raw)*/
	int16_t zgyro; /*< Angular speed around Z axis (raw)*/
	int16_t xmag; /*< X Magnetic field (raw)*/
	int16_t ymag; /*< Y Magnetic field (raw)*/
	int16_t zmag; /*< Z Magnetic field (raw)*/
}) mavlink_raw_imu_t;

#define MAVLINK_MSG_ID_ATTITUDE 30
MAVPACKED(
	typedef struct __mavlink_attitude_t {
	uint32_t time_boot_ms; /*< Timestamp (milliseconds since system boot)*/
	float roll; /*< Roll angle (rad, -pi..+pi)*/
	float pitch; /*< Pitch angle (rad, -pi..+pi)*/
	float yaw; /*< Yaw angle (rad, -pi..+pi)*/
	float rollspeed; /*< Roll angular speed (rad/s)*/
	float pitchspeed; /*< Pitch angular speed (rad/s)*/
	float yawspeed; /*< Yaw angular speed (rad/s)*/
}) mavlink_attitude_t;


#define MAVLINK_MSG_ID_ATTITUDE_QUATERNION 31
MAVPACKED(
	typedef struct __mavlink_attitude_quaternion_t {
	uint32_t time_boot_ms; /*< Timestamp (milliseconds since system boot)*/
	float q1; /*< Quaternion component 1, w (1 in null-rotation)*/
	float q2; /*< Quaternion component 2, x (0 in null-rotation)*/
	float q3; /*< Quaternion component 3, y (0 in null-rotation)*/
	float q4; /*< Quaternion component 4, z (0 in null-rotation)*/
	float rollspeed; /*< Roll angular speed (rad/s)*/
	float pitchspeed; /*< Pitch angular speed (rad/s)*/
	float yawspeed; /*< Yaw angular speed (rad/s)*/
}) mavlink_attitude_quaternion_t;


#define MAVLINK_MSG_ID_LOCAL_POSITION_NED 32
MAVPACKED(
	typedef struct __mavlink_local_position_ned_t {
	uint32_t time_boot_ms; /*< Timestamp (milliseconds since system boot)*/
	float x; /*< X Position*/
	float y; /*< Y Position*/
	float z; /*< Z Position*/
	float vx; /*< X Speed*/
	float vy; /*< Y Speed*/
	float vz; /*< Z Speed*/
}) mavlink_local_position_ned_t;

MAVPACKED(
	typedef struct __mavlink_hil_gps_t {
	uint64_t time_usec; /*< Timestamp (microseconds since UNIX epoch or microseconds since system boot)*/
	int32_t lat; /*< Latitude (WGS84), in degrees * 1E7*/
	int32_t lon; /*< Longitude (WGS84), in degrees * 1E7*/
	int32_t alt; /*< Altitude (AMSL, not WGS84), in meters * 1000 (positive for up)*/
	uint16_t eph; /*< GPS HDOP horizontal dilution of position in cm (m*100). If unknown, set to: 65535*/
	uint16_t epv; /*< GPS VDOP vertical dilution of position in cm (m*100). If unknown, set to: 65535*/
	uint16_t vel; /*< GPS ground speed in cm/s. If unknown, set to: 65535*/
	int16_t vn; /*< GPS velocity in cm/s in NORTH direction in earth-fixed NED frame*/
	int16_t ve; /*< GPS velocity in cm/s in EAST direction in earth-fixed NED frame*/
	int16_t vd; /*< GPS velocity in cm/s in DOWN direction in earth-fixed NED frame*/
	uint16_t cog; /*< Course over ground (NOT heading, but direction of movement) in degrees * 100, 0.0..359.99 degrees. If unknown, set to: 65535*/
	uint8_t fix_type; /*< 0-1: no fix, 2: 2D fix, 3: 3D fix. Some applications will not use the value of this field unless it is at least two, so always correctly fill in the fix.*/
	uint8_t satellites_visible; /*< Number of satellites visible. If unknown, set to 255*/
}) mavlink_hil_gps_t;

#define MAVLINK_MSG_ID_MISSION_ACK 47
MAVPACKED(
	typedef struct __mavlink_mission_ack_t {
	uint8_t target_system; /*< System ID*/
	uint8_t target_component; /*< Component ID*/
	uint8_t type; /*< See MAV_MISSION_RESULT enum*/
	uint8_t mission_type; /*< Mission type, see MAV_MISSION_TYPE*/
}) mavlink_mission_ack_t;

#define MAVLINK_MSG_ID_NAMED_VALUE_INT 252
MAVPACKED(
	typedef struct __mavlink_named_value_int_t {
	uint32_t time_boot_ms; /*< Timestamp (milliseconds since system boot)*/
	int32_t value; /*< Signed integer value*/
	char name[10]; /*< Name of the debug variable*/
}) mavlink_named_value_int_t;