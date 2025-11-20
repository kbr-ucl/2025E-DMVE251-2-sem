# Requirements Document

## Introduction

This document specifies the requirements for a Booking System that allows customers to create, update, and view their bookings. The system enforces business rules to prevent overlapping bookings and ensures all bookings are scheduled for future time slots. The system follows a clean architecture with domain-driven design principles, separating business logic from infrastructure concerns.

## Glossary

- **Booking System**: The software system that manages customer bookings
- **Kunde**: A customer who can create and manage bookings
- **Booking**: A time-based reservation with a start time and end time associated with a specific customer
- **Overlap**: A condition where two bookings for the same customer have intersecting time periods
- **Time Slot**: The period between a booking's start time and end time

## Requirements

### Requirement 1

**User Story:** As a customer, I want to create a new booking for myself, so that I can reserve a time slot for my needs.

#### Acceptance Criteria

1. WHEN a customer provides a valid customer ID, start time, and end time, THE Booking System SHALL create a new booking and associate it with that customer
2. WHEN a customer attempts to create a booking with a start time that is not before the end time, THEN THE Booking System SHALL reject the booking and signal a validation error
3. WHEN a customer attempts to create a booking with a start time in the past or present, THEN THE Booking System SHALL reject the booking and signal a validation error
4. WHEN a customer attempts to create a booking that overlaps with an existing booking for that customer, THEN THE Booking System SHALL reject the booking and signal a validation error
5. WHEN a customer provides an invalid customer ID, THEN THE Booking System SHALL reject the booking and signal an error

### Requirement 2

**User Story:** As a customer, I want to update one of my existing bookings, so that I can change the time slot if my plans change.

#### Acceptance Criteria

1. WHEN a customer provides a valid booking ID, customer ID, new start time, and new end time for their own booking, THE Booking System SHALL update the booking with the new times
2. WHEN a customer attempts to update a booking with a start time that is not before the end time, THEN THE Booking System SHALL reject the update and signal a validation error
3. WHEN a customer attempts to update a booking with a start time in the past or present, THEN THE Booking System SHALL reject the update and signal a validation error
4. WHEN a customer attempts to update a booking such that it would overlap with another existing booking for that customer, THEN THE Booking System SHALL reject the update and signal a validation error
5. WHEN a customer attempts to update a booking that does not belong to them, THEN THE Booking System SHALL reject the update and signal an ownership error
6. WHEN a customer provides an invalid booking ID, THEN THE Booking System SHALL reject the update and signal an error

### Requirement 3

**User Story:** As a customer, I want to view all my bookings, so that I can see what time slots I have reserved.

#### Acceptance Criteria

1. WHEN a customer requests their bookings with a valid customer ID, THE Booking System SHALL return a list of all bookings associated with that customer
2. WHEN a customer requests their bookings, THE Booking System SHALL include the booking ID, customer ID, start time, and end time for each booking
3. WHEN a customer with no bookings requests their bookings, THE Booking System SHALL return an empty list

### Requirement 4

**User Story:** As a system administrator, I want the system to prevent overlapping bookings for each customer, so that customers cannot double-book themselves.

#### Acceptance Criteria

1. WHEN the Booking System checks for overlaps, THE Booking System SHALL detect any existing booking for the customer that has a time period intersecting with the proposed booking
2. WHEN the Booking System updates an existing booking, THE Booking System SHALL exclude that booking from the overlap check
3. WHEN two bookings have adjacent time slots with no gap, THE Booking System SHALL allow both bookings to exist

### Requirement 5

**User Story:** As a system architect, I want clear separation between domain logic, application services, and infrastructure, so that the system is maintainable and testable.

#### Acceptance Criteria

1. WHEN domain entities enforce business rules, THE Booking System SHALL validate those rules within the domain layer without depending on infrastructure
2. WHEN the application layer coordinates operations, THE Booking System SHALL use repository interfaces to abstract data access
3. WHEN infrastructure implementations change, THE Booking System SHALL maintain domain and application logic unchanged
