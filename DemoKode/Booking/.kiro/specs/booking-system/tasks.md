# Implementation Plan

- [ ] 1. Set up property-based testing infrastructure
  - Install FsCheck NuGet package in Booking.Domain.Test project
  - Configure FsCheck to run 100 iterations per property test
  - Create base test class with common FsCheck configuration
  - _Requirements: All (testing infrastructure)_

- [ ] 2. Create test generators and helpers
  - [ ] 2.1 Implement custom generators for domain types
    - Create generator for valid future DateTime ranges
    - Create generator for invalid DateTime ranges (start >= end)
    - Create generator for past/present DateTime values
    - Create generator for overlapping time ranges
    - Create generator for adjacent time ranges
    - Create generator for customer IDs
    - _Requirements: 1.1, 1.2, 1.3, 1.4, 4.3_
  
  - [ ] 2.2 Create test helper utilities
    - Implement FakeCurrentDateTime for testing time-dependent logic
    - Create in-memory database setup helper
    - Create test data builder for Booking entities
    - Create test data builder for Kunde entities
    - _Requirements: 1.3, 2.3_

- [ ] 3. Implement property-based tests for booking creation
  - [ ] 3.1 Write property test for valid booking creation
    - **Property 1: Valid booking creation succeeds**
    - **Validates: Requirements 1.1**
  
  - [ ]* 3.2 Write property test for invalid time range rejection
    - **Property 2: Invalid time ranges are rejected**
    - **Validates: Requirements 1.2, 2.2**
  
  - [ ]* 3.3 Write property test for overlap prevention
    - **Property 3: Overlapping bookings are prevented**
    - **Validates: Requirements 1.4, 2.4**

- [ ] 4. Implement property-based tests for booking updates
  - [ ] 4.1 Write property test for booking update identity preservation
    - **Property 4: Booking updates preserve identity**
    - **Validates: Requirements 2.1**
  
  - [ ]* 4.2 Write property test for ownership enforcement
    - **Property 5: Ownership is enforced**
    - **Validates: Requirements 2.5**
  
  - [ ]* 4.3 Write property test for self-overlap exclusion
    - **Property 7: Self-overlap is excluded during updates**
    - **Validates: Requirements 4.2**

- [ ] 5. Implement property-based tests for booking queries
  - [ ] 5.1 Write property test for complete booking data retrieval
    - **Property 6: Query returns complete booking data**
    - **Validates: Requirements 3.1, 3.2**

- [ ] 6. Implement property-based tests for overlap detection logic
  - [ ]* 6.1 Write property test for adjacent bookings
    - **Property 8: Adjacent bookings are allowed**
    - **Validates: Requirements 4.3**
  
  - [ ]* 6.2 Write property test for overlap symmetry
    - **Property 9: Overlap detection is symmetric**
    - **Validates: Requirements 4.1**

- [ ] 7. Checkpoint - Ensure all tests pass
  - Ensure all tests pass, ask the user if questions arise.

- [ ]* 8. Add unit tests for edge cases
  - [ ]* 8.1 Write unit test for empty customer booking list
    - Test querying bookings for customer with no bookings returns empty list
    - _Requirements: 3.3_
  
  - [ ]* 8.2 Write unit test for non-existent booking
    - Test updating non-existent booking throws NotFoundException
    - _Requirements: 2.6_
  
  - [ ]* 8.3 Write unit test for non-existent customer
    - Test creating booking with non-existent customer throws exception
    - _Requirements: 1.5_
  
  - [ ]* 8.4 Write unit test for past/present time rejection
    - Test creating booking with past start time throws ValidationException
    - Test creating booking with present start time throws ValidationException
    - _Requirements: 1.3, 2.3_

- [ ] 9. Final Checkpoint - Ensure all tests pass
  - Ensure all tests pass, ask the user if questions arise.
