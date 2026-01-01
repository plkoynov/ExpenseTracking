# US-015: Role-Based Access Control

## User Story
**As the** system  
**I want to** enforce role-based access to features  
**So that** employees and managers only see functionality appropriate to their role

---

## Description
The system must enforce different permissions and views based on whether a user is registered as an Employee or Manager. This ensures proper separation of concerns and prevents unauthorized actions.

---

## Acceptance Criteria

### AC-1: Employee view restrictions
- **Given** I am logged in as an Employee
- **When** I view the expenses list
- **Then** I see only my own expenses
- **And** I do NOT see expenses created by other employees
- **And** I do NOT see approve/reject buttons on any expenses (including my own submitted expenses)

### AC-2: Manager view permissions
- **Given** I am logged in as a Manager
- **When** I view the expenses list
- **Then** I see all expenses from all users (including my own)
- **And** I can see approve/reject buttons on submitted expenses created by others
- **And** I can filter and manage all expenses

### AC-3: Manager can also be an employee
- **Given** I am logged in as a Manager
- **When** I create and submit my own expense
- **Then** the expense is created successfully
- **And** other managers can approve/reject it
- **And** I cannot approve or reject my own expense (as per US-009/US-010)
- **And** I see my own expense in the "All Expenses" list along with everyone else's

### AC-4: Employee cannot access manager actions
- **Given** I am logged in as an Employee
- **When** I try to directly access manager-only functionality (e.g., approve action, view all expenses)
- **Then** I receive an "Unauthorized" or "Forbidden" error
- **And** the action is not performed

### AC-5: Role is displayed in UI
- **Given** I am logged in
- **When** I view the system header/navigation
- **Then** I see my identity and role displayed clearly
- **And** the format is:  "Logged in as:  [Full Name] ([Role])"
- **And** Example: "Logged in as: John Doe (Manager)"

### AC-6: Navigation reflects role - Employee
- **Given** I am logged in as an Employee
- **When** I view the navigation menu
- **Then** I see options like: 
  - "My Expenses" (or "Expenses")
  - "Create Expense"
  - "Log Out"
- **And** I do NOT see manager-specific menu items like "All Expenses" or "Pending Approvals"

### AC-7: Navigation reflects role - Manager
- **Given** I am logged in as a Manager
- **When** I view the navigation menu
- **Then** I see options like:
  - "All Expenses" (or "Review Expenses")
  - "Pending Approvals" (quick filter)
  - "Create Expense" (for my own expenses)
  - "Log Out"

### AC-8: Backend enforces permissions
- **Given** I am logged in with any role
- **When** I attempt any action (view, create, edit, delete, approve, reject)
- **Then** the system validates my permissions on the backend (server-side)
- **And** denies the action if I lack permission, regardless of frontend state
- **And** returns appropriate error: 
  - 401 (Unauthorized) if not logged in
  - 403 (Forbidden) if logged in but insufficient permissions

### AC-9: Session includes role information
- **Given** I have successfully logged in
- **When** my session is created
- **Then** my role (Employee or Manager) is included in the session data
- **And** this role is used to determine access for all subsequent requests
- **And** my role is displayed consistently throughout the session

---

## Technical Notes
- Role should be stored in user table as ENUM or string:  "Employee" or "Manager"
- Role should be included in session/token data for efficient authorization checks
- Backend API endpoints must verify user role before executing privileged operations
- Frontend should hide UI elements based on role, but backend must also enforce permissions
- All protected routes/actions must check: 
  1. Is user authenticated? (valid session/token)
  2. Does user have required role? 
  3. Does user meet additional criteria?  (e.g., not approving own expense)

---

## UI/UX Considerations
- Clear visual indication of user's role in header at all times
- Different dashboard/landing pages for Employee vs Manager
- Consistent use of role-based menu items and buttons
- "Logged in as" display should be visible but not intrusive
- Role display helps users understand what they can do

---

## Security Notes
- Never rely solely on frontend role checks - always validate on backend
- API endpoints must check user role and user ID for ownership validation
- Return appropriate HTTP status codes: 
  - 401 (Unauthorized) if not logged in
  - 403 (Forbidden) if insufficient permissions
- Session/token must include role and be tamper-proof (signed or server-side)

---

## Dependencies
- US-013 (User Registration) - role is set during registration
- US-014 (User Login) - role is loaded into session
- All expense user stories - role determines what actions are available