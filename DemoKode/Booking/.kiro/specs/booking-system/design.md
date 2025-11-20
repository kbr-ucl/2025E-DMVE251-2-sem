# Design Document

## Overview

The Booking System is designed using Clean Architecture principles with Domain-Driven Design (DDD). The system separates concerns into distinct layers: Domain (business logic and entities), Application (use case orchestration), Infrastructure (data access and external services), and Port/Driving (API contracts). This separation ensures the core business logic remains independent of infrastructure concerns and external frameworks.

The system manages customer bookings with strict business rules enforced at the domain level, including overlap prevention, time validation, and ownership verification. The architecture follows the Command Query Responsibility Segregation (CQS) pattern, separating write operations (commands) from read operations (queries).

## Architecture

### Layered Architecture

```
┌─────────────────────────────────────┐
│     Port.Driving (API Contracts)    │
│  IBookingCommand, IBookingQuery     │
└─────────────────────────────────────┘
              ↓
┌─────────────────────────────────────┐
│      Application Layer              │
│  BookingCommandHandler              │
│  Repository Interfaces              │
└─────────────────────────────────────┘
              ↓
┌─────────────────────────────────────┐
│       Domain Layer                  │
│  Entities: Booking, Kunde           │
│  Domain Services: IBookingOverlap   │
│  Business Rules & Validation        │
└─────────────────────────────────────┘
              ↓
┌─────────────────────────────────────┐
│    Infrastructure Layer             │
│  BookingRepository                  │
│  BookingQueryHandler                │
│  BookingOverlapCheck                │
│  Entity Framework DbContext         │
└─────────────────────────────────────┘
```

### Key Architectural Patterns

1. **Hexagonal Architecture (Ports & Adapters)**: The Port.Driving layer defines interfaces that external systems use to interact with the application
2. **Repository Pattern**: Data access is abstracted through repository interfaces defined in the Application layer
3. **Domain Services**: Complex business logic that doesn't naturally fit in entities (e.g., overlap checking) is encapsulated in domain services
4. **CQS Pattern**: Commands (write operations) and Queries (read operations) are separated into distinct interfaces

## Components and Interfaces

### Domain Layer

#### Entities

**Booking**
- Properties: `Id`, `StartTid`, `SlutTid`, `Kunde`
- Constructor: Validates business rules and creates a new booking
- Methods:
  - `UpdateStartSlut(DateTime start, DateTime slut, IBookingOverlapCheck overlapCheck, ICurrentDateTime now)`: Updates booking times with validation
- Business Rules Enforced:
  - Start time must be before end time
  - Start time must be in the future
  - No overlapping bookings for the same customer
  - Customer must exist

**Kunde**
- Properties: `Id`, `Name`, `Bookings`
- Represents a customer who owns bookings

**EntityBase**
- Base class providing `Id` property for all entities

#### Domain Services

**IBookingOverlapCheck**
- `HasOverlap(int kundeId, DateTime start, DateTime end, int? excludeBookingId = null)`: Checks if a time slot overlaps with existing bookings
- The `excludeBookingId` parameter allows excluding a specific booking during updates

**ICurrentDateTime**
- `Now()`: Provides current date/time (abstraction for testability)

#### Domain Exceptions

- `ValidationException`: Thrown when business rule validation fails
- `OwnershipException`: Thrown when a customer attempts to modify a booking they don't own
- `NotFoundException`: Thrown when a requested entity doesn't exist

### Application Layer

#### Command Handler

**BookingCommandHandler** implements `IBookingCommand`
- `CreateBooking(CreateBookingCommand command)`: Orchestrates booking creation
  - Load customer from repository
  - Create booking entity (domain validates rules)
  - Save booking to repository
- `UpdateBooking(UpdateBookingCommand command)`: Orchestrates booking updates
  - Load booking from repository
  - Verify ownership
  - Update booking (domain validates rules)
  - Save changes

#### Repository Interfaces

**IBookingRepository**
- `AddBooking(Booking booking)`: Persists a new booking
- `GetBooking(int id)`: Retrieves a booking by ID
- `SaveBooking(Booking booking)`: Persists changes to an existing booking

**IKundeRepository**
- `Get(int id)`: Retrieves a customer by ID

### Port.Driving Layer

**IBookingCommand**
- `CreateBooking(CreateBookingCommand command)`
- `UpdateBooking(UpdateBookingCommand command)`
- Command DTOs: `CreateBookingCommand`, `UpdateBookingCommand`

**IBookingQuery**
- `GetAllByKundeId(int kundeId)`: Returns all bookings for a customer
- Query DTOs: `BookingDto`, `GetAllByKundeRequest`

### Infrastructure Layer

**BookingRepository**
- Implements `IBookingRepository`
- Uses Entity Framework Core for data persistence
- Includes related entities (Kunde) when loading bookings

**BookingQueryHandler**
- Implements `IBookingQuery`
- Uses Entity Framework Core with `AsNoTracking()` for read-only queries
- Projects entities to DTOs

**BookingOverlapCheck**
- Implements `IBookingOverlapCheck`
- Uses Entity Framework Core to query for overlapping bookings
- Implements overlap detection using interval logic: `b.StartTid < end && b.SlutTid > start`

**BookingContext**
- Entity Framework DbContext
- Manages database schema and entity tracking

## Data Models

### Database Schema

**Bookinger Table**
- `Id` (int, primary key)
- `StartTid` (DateTime)
- `SlutTid` (DateTime)
- `KundeId` (int, foreign key)

**Kunde Table**
- `Id` (int, primary key)
- `Name` (string)

### Relationships

- One-to-Many: Kunde → Bookings
- A customer can have multiple bookings
- Each booking belongs to exactly one customer

### DTOs

**BookingDto**
- `KundeId` (int)
- `BookingId` (int)
- `StartTid` (DateTime)
- `SlutTid` (DateTime)

**CreateBookingCommand**
- `KundeId` (int)
- `StartTid` (DateTime)
- `SlutTid` (DateTime)

**UpdateBookingCommand**
- `KundeId` (int)
- `BookingId` (int)
- `StartTid` (DateTime)
- `SlutTid` (DateTime)


## Correctness Properties

*A property is a characteristic or behavior that should hold true across all valid executions of a system—essentially, a formal statement about what the system should do. Properties serve as the bridge between human-readable specifications and machine-verifiable correctness guarantees.*

### Property 1: Valid booking creation succeeds

*For any* valid customer ID and any valid future time range (where start < end and start > now), creating a booking should succeed and the booking should be associated with that customer and retrievable from the system.

**Validates: Requirements 1.1**

### Property 2: Invalid time ranges are rejected

*For any* time range where start time is greater than or equal to end time, attempting to create or update a booking should be rejected with a validation error.

**Validates: Requirements 1.2, 2.2**

### Property 3: Overlapping bookings are prevented

*For any* customer with an existing booking, attempting to create or update another booking for that customer with a time range that overlaps the existing booking should be rejected with a validation error.

**Validates: Requirements 1.4, 2.4**

### Property 4: Booking updates preserve identity

*For any* existing booking and any valid new time range that doesn't overlap other bookings, updating the booking should change the times while preserving the booking ID and customer association.

**Validates: Requirements 2.1**

### Property 5: Ownership is enforced

*For any* booking and any customer ID that differs from the booking's owner, attempting to update that booking should be rejected with an ownership error.

**Validates: Requirements 2.5**

### Property 6: Query returns complete booking data

*For any* customer with bookings, querying their bookings should return all bookings for that customer with complete data (booking ID, customer ID, start time, end time) matching the stored values.

**Validates: Requirements 3.1, 3.2**

### Property 7: Self-overlap is excluded during updates

*For any* existing booking, updating that booking to a new time range should not fail due to overlapping with itself, even if the new range would overlap the old range.

**Validates: Requirements 4.2**

### Property 8: Adjacent bookings are allowed

*For any* customer, creating two bookings where the end time of one equals the start time of the other should succeed, as adjacent time slots do not overlap.

**Validates: Requirements 4.3**

### Property 9: Overlap detection is symmetric

*For any* two time ranges A and B, if A overlaps B, then B overlaps A. The overlap detection logic should be symmetric and consistent.

**Validates: Requirements 4.1**

## Error Handling

### Exception Hierarchy

The system uses a custom exception hierarchy rooted in `DomainException`:

- **ValidationException**: Thrown when business rule validation fails
  - Invalid time ranges (start >= end)
  - Past or present start times
  - Overlapping bookings
- **OwnershipException**: Thrown when ownership verification fails
  - Customer attempting to update another customer's booking
- **NotFoundException**: Thrown when requested entities don't exist
  - Invalid booking ID
  - Invalid customer ID

### Error Handling Strategy

1. **Domain Layer**: Validates business rules and throws domain exceptions
2. **Application Layer**: Catches domain exceptions and can add context if needed
3. **Infrastructure Layer**: Translates data access errors to domain exceptions (e.g., NotFoundException)
4. **Port Layer**: Consumers handle exceptions and translate to appropriate responses (HTTP status codes, error messages, etc.)

### Validation Points

- **Constructor Validation**: The Booking entity validates all business rules in its constructor
- **Update Validation**: The `UpdateStartSlut` method re-validates all rules before applying changes
- **Repository Validation**: Repositories throw NotFoundException when entities don't exist
- **Application Validation**: Command handlers verify ownership before delegating to domain

## Testing Strategy

### Dual Testing Approach

The system requires both unit testing and property-based testing to ensure comprehensive coverage:

- **Unit tests** verify specific examples, edge cases, and error conditions
- **Property tests** verify universal properties that should hold across all inputs
- Together they provide comprehensive coverage: unit tests catch concrete bugs, property tests verify general correctness

### Unit Testing

Unit tests will cover:

- **Specific examples**: Creating a booking with known values, updating with specific times
- **Edge cases**: Empty customer lists, boundary times (midnight, year boundaries)
- **Error conditions**: Null parameters, invalid IDs, specific overlap scenarios
- **Integration points**: Repository interactions, database context behavior

Key unit test scenarios:
- Creating a booking with valid data succeeds
- Updating a booking with valid data succeeds
- Querying bookings for a customer with no bookings returns empty list
- Attempting to update a non-existent booking throws NotFoundException
- Attempting to create a booking with null customer throws ArgumentNullException

### Property-Based Testing

The system will use **FsCheck** (for C#/.NET) as the property-based testing library.

**Configuration**:
- Each property-based test MUST run a minimum of 100 iterations
- Each property-based test MUST be tagged with a comment explicitly referencing the correctness property from this design document
- Tag format: `**Feature: booking-system, Property {number}: {property_text}**`
- Each correctness property MUST be implemented by a SINGLE property-based test

**Property Test Coverage**:

Each of the 9 correctness properties listed above will have a corresponding property-based test:

1. **Property 1 Test**: Generate random valid customers and future time ranges, verify booking creation succeeds
2. **Property 2 Test**: Generate random invalid time ranges (start >= end), verify rejection
3. **Property 3 Test**: Generate random existing bookings and overlapping time ranges, verify rejection
4. **Property 4 Test**: Generate random bookings and valid updates, verify identity preservation
5. **Property 5 Test**: Generate random bookings and different customer IDs, verify ownership rejection
6. **Property 6 Test**: Generate random customers with random bookings, verify complete data retrieval
7. **Property 7 Test**: Generate random bookings and updates, verify self-overlap exclusion
8. **Property 8 Test**: Generate random adjacent time ranges, verify both bookings succeed
9. **Property 9 Test**: Generate random time range pairs, verify overlap symmetry

**Generator Strategy**:

Smart generators will constrain the input space intelligently:
- **Valid time ranges**: Generate start time in future, end time after start
- **Invalid time ranges**: Generate start >= end or start <= now
- **Overlapping ranges**: Generate base range, then generate range that intersects it
- **Adjacent ranges**: Generate base range, then generate range starting at base end time
- **Customer IDs**: Generate from a bounded set to ensure some customers have multiple bookings
- **Booking IDs**: Track generated bookings to enable update testing

### Test Organization

- **Unit tests**: Located in `Booking.Domain.Test` project
- **Property-based tests**: Will be added to `Booking.Domain.Test` project
- **Test naming**: Descriptive names explaining what is being tested
- **Test co-location**: Tests organized by component (BookingTests, KundeTests, etc.)

### Testing Without Mocks

Tests should avoid mocking when possible to validate real functionality:
- Use in-memory database for repository tests
- Use real domain services with test implementations (e.g., FakeCurrentDateTime)
- Only mock external dependencies that cannot be easily substituted

