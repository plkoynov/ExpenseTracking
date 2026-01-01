# Product Requirements Document: Expense Management System

## Document Information

- **Version**: 1.0
- **Date**: 2026-01-01
- **Owner**: Product Management

---

## Table of Contents

1. [Executive Summary](#1-executive-summary)
2. [Goals and Objectives](#2-goals-and-objectives)
3. [User Roles and Permissions](#3-user-roles-and-permissions)
4. [User Registration and Authentication](#4-user-registration-and-authentication)
5. [Expense Management Workflow](#5-expense-management-workflow)
6. [Data Requirements](#6-data-requirements)
7. [Access Control and Security](#7-access-control-and-security)
8. [User Experience Requirements](#8-user-experience-requirements)
9. [Out of Scope for v1](#9-out-of-scope-for-v1)
10. [Acceptance Criteria](#10-acceptance-criteria)
11. [User Stories Reference](#11-user-stories-reference)

---

## 1. Executive Summary

### 1.1 Problem Statement

A small-to-medium company needs a simple internal system to manage employee expenses. Currently, expense handling is inefficient:

- Receipts sent via email or chat
- Inconsistent use of spreadsheets
- Unclear and slow approvals
- No visibility into expense status
- Lost context around decisions
- No audit trail

### 1.2 Solution

A structured, reliable internal expense management system that enables:

- Employees to submit expenses in a clear, consistent way
- Managers to review and decide quickly
- Everyone to know the current status of expenses
- Complete history of all decisions

### 1.3 Key Principles

1. **Clear** – No ambiguity about what can be done and when
2. **Structured** – Same process for everyone
3. **Traceable** – Decisions and comments are visible later
4. **Simple** – Minimal features, minimal learning curve

---

## 2. Goals and Objectives

### 2.1 Primary Goals

- Provide a structured way for employees to submit expenses
- Enable managers to review and approve/reject expenses with clear reasoning
- Maintain transparency and traceability of all decisions
- Eliminate manual tracking via email and spreadsheets
- Reduce errors and delays in the expense process

### 2.2 Success Metrics

- All expense submissions include required information
- Every approval/rejection has a documented reason
- Users can always see current status of their expenses
- Complete audit trail for all expenses
- Zero unauthorized access to restricted features

### 2.3 Non-Goals (v1)

- Payment processing or bank integrations
- Receipt attachment storage
- Advanced reporting or analytics
- Mobile applications
- Multi-level approval workflows
- Budget tracking or spending limits

---

## 3. User Roles and Permissions

### 3.1 Employee Role

**Primary Purpose:** Submit and track their own expenses

**Capabilities:**

- Create new expenses and save as drafts
- Edit draft expenses before submission
- Delete draft expenses
- Submit expenses for approval
- View only their own expenses
- Filter and search their own expenses
- See approval/rejection decisions and comments
- Edit and resubmit rejected expenses

**Restrictions:**

- Cannot view expenses created by other employees
- Cannot approve or reject any expenses
- Cannot modify submitted, approved, or rejected expenses (except re-editing rejected ones)

### 3.2 Manager Role

**Primary Purpose:** Review and approve/reject expenses

**Capabilities:**

- **All Employee capabilities** (can create and submit their own expenses)
- View all expenses from all employees
- Filter and search all expenses
- Approve submitted expenses with mandatory comment
- Reject submitted expenses with mandatory comment
- See complete history and audit trail of all expenses

**Restrictions:**

- Cannot approve or reject their own expenses
- Cannot edit expenses created by other users
- Cannot modify approved expenses
- Cannot delete submitted, approved, or rejected expenses

### 3.3 Role Assignment

- Users self-select their role during registration (no admin approval)
- Role cannot be changed after registration (v1)
- A user can function as both Employee and Manager
- No administrative role exists in v1

---

## 4. User Registration and Authentication

### 4.1 User Information

The system must collect and store the following for each user:

| Information       | Required? | Purpose                             | Rules                   |
| ----------------- | --------- | ----------------------------------- | ----------------------- |
| Full Name         | Yes       | Display user identity in the system | 1-255 characters        |
| Email Address     | Yes       | Login identifier                    | Valid format, unique    |
| Password          | Yes       | Authentication credential           | Minimum 6 characters    |
| Role              | Yes       | Determine access permissions        | "Employee" or "Manager" |
| Registration Date | Auto      | Track when account was created      | System-generated        |

**Data NOT collected in v1:**

- Employee ID, Department, Manager assignment, Phone number, Job title, Profile photo

### 4.2 Registration Process

#### Access

- Registration form must be accessible without logging in
- Clear link from login page: "Don't have an account? Register"

#### Registration Form Fields

1. Full Name (text input, required)
2. Email Address (email input, required)
3. Password (secure input, required, characters masked)
4. Confirm Password (secure input, required)
5. Role Selection (radio buttons or dropdown: "Employee" or "Manager", required)

#### Validation Rules

| Field            | Validation                                | Error Message                              |
| ---------------- | ----------------------------------------- | ------------------------------------------ |
| Full Name        | Not empty                                 | "Full name is required"                    |
| Email            | Valid email format                        | "Please enter a valid email address"       |
| Email            | Not already registered (case-insensitive) | "This email address is already registered" |
| Password         | At least 6 characters                     | "Password must be at least 6 characters"   |
| Confirm Password | Must match Password field                 | "Passwords do not match"                   |
| Role             | Must select one option                    | "Please select your role"                  |

#### Success Behavior

- User account is created
- User is automatically logged in
- User is redirected to main expenses page
- Welcome message displayed: "Welcome, [Full Name]!"

### 4.3 Login Process

#### Login Form Fields

1. Email Address (text input, required)
2. Password (secure input, required, characters masked)

#### Login Behavior

**Successful Login:**

- User is authenticated
- User is redirected to role-appropriate view
- Session is created (remains active for 24 hours of inactivity)

**Failed Login:**

- Generic error message: "Invalid email or password"
- Do NOT reveal whether email exists (security requirement)
- Form fields are cleared

#### Email Matching

- Case-insensitive (john@company.com = JOHN@COMPANY.COM)

#### Link to Registration

- "Don't have an account? Register" link visible on login page

### 4.4 Session Management

**Session Duration:**

- Users remain logged in for 24 hours of inactivity
- No re-login required when navigating between pages
- After 24 hours of inactivity, must log in again

**Logout:**

- Clear "Log Out" button/link in system header
- Session immediately terminated
- Redirect to login page
- Confirmation message: "You have been logged out"

**User Identity Display:**

- While logged in, header shows: "Logged in as: [Full Name] ([Role])"
- Example: "Logged in as: John Doe (Manager)"

### 4.5 Password Requirements

**Complexity (Minimal for Internal System):**

- Minimum 6 characters
- No other requirements (uppercase, numbers, special characters not required)

**Security:**

- Passwords stored securely (never in plain text, must be hashed)
- Passwords never displayed after entry
- Password fields mask characters while typing

**Out of Scope for v1:**

- Password reset/forgotten password
- "Remember me" functionality
- Password expiration or forced changes

### 4.6 Initial System Setup

- No pre-seeded users when system is first deployed
- First users register themselves
- No user import from files or external systems
- Users choose their own roles during registration

---

## 5. Expense Management Workflow

### 5.1 Expense Lifecycle

```
Draft → Submitted → Approved
                 ↘ Rejected → (can be edited) → Submitted
```

**Status Definitions:**

- **Draft:** Created but not submitted, editable by creator
- **Submitted:** Awaiting manager review, locked from editing
- **Approved:** Accepted by manager, permanently locked
- **Rejected:** Declined by manager with explanation, can be edited and resubmitted

### 5.2 Creating Expenses

#### Who Can Create

- Any Employee
- Any Manager (for their own expenses)

#### Create Expense Form

Clear "Create New Expense" button/link in main navigation

**Required Fields:**

- Date of expense (date picker)
- Amount (numeric input, positive number)
- Currency (dropdown: USD, EUR, GBP, others as configured)
- Category (dropdown: Travel, Meals, Office Supplies, Software/Subscriptions, Other)

**Optional Fields:**

- Description (text area)

#### Save as Draft

- Validates required fields before saving
- Status set to "Draft"
- Creator can return to edit later
- Confirmation message: "Expense saved as draft"

### 5.3 Editing Expenses

#### Draft Expenses

- Creator can edit any field
- Creator can delete the expense (with confirmation dialog)
- Changes are saved, status remains "Draft"

#### Rejected Expenses

- Creator can edit any field to fix issues
- Original rejection comment preserved in history
- Can be resubmitted after editing

#### Submitted/Approved Expenses

- Cannot be edited by anyone
- Details are read-only

### 5.4 Deleting Expenses

#### Draft Expenses

- Creator can delete
- Confirmation dialog: "Are you sure you want to delete this expense?"
- Permanent deletion (no recovery)

#### Submitted/Approved/Rejected Expenses

- Cannot be deleted by anyone
- Must be preserved for audit trail

### 5.5 Submitting Expenses

#### Who Can Submit

- Creator of the expense (when status = Draft)

#### Submit Action

- Validates all required fields are present
- Status changes from "Draft" to "Submitted"
- Submission timestamp recorded
- Expense becomes locked (read-only)
- Confirmation message: "Expense submitted for approval"
- Expense appears in managers' review queue

### 5.6 Approving Expenses

#### Who Can Approve

- Any Manager
- EXCEPT the manager cannot approve their own expense

#### Approve Action

1. Manager views submitted expense
2. Clicks "Approve" button
3. System presents approval form with mandatory comment field
4. Manager enters approval comment (required, cannot be empty)
5. Confirms approval

**Result:**

- Status changes from "Submitted" to "Approved"
- Approval comment saved (immutable)
- Approver's user ID and name recorded
- Approval timestamp recorded
- Expense permanently locked (cannot be edited)
- Confirmation message: "Expense approved"

#### Visibility

- Employee sees:
  - Status: "Approved"
  - Approval comment
  - Manager name who approved
  - Approval timestamp

### 5.7 Rejecting Expenses

#### Who Can Reject

- Any Manager
- EXCEPT the manager cannot reject their own expense

#### Reject Action

1. Manager views submitted expense
2. Clicks "Reject" button
3. System presents rejection form with mandatory comment field
4. Manager enters rejection comment explaining why (required, cannot be empty)
5. Confirms rejection

**Result:**

- Status changes from "Submitted" to "Rejected"
- Rejection comment saved (immutable)
- Rejector's user ID and name recorded
- Rejection timestamp recorded
- Employee can now edit and resubmit
- Confirmation message: "Expense rejected"

#### Visibility

- Employee sees:
  - Status: "Rejected"
  - Rejection comment clearly visible
  - Manager name who rejected
  - Rejection timestamp
  - "Edit" button to make corrections

### 5.8 Resubmitting Rejected Expenses

#### Process

1. Employee views rejected expense
2. Sees rejection comment explaining what to fix
3. Clicks "Edit"
4. Updates expense fields
5. Clicks "Resubmit" (or "Submit")

**Result:**

- Status changes from "Rejected" to "Submitted"
- New submission timestamp recorded
- Previous rejection comment preserved in history
- Expense re-enters managers' review queue
- Confirmation message: "Expense resubmitted for approval"

---

## 6. Data Requirements

### 6.1 User Data

**What Must Be Stored:**

| Data Item         | Rules                                             | Can Change? |
| ----------------- | ------------------------------------------------- | ----------- |
| User ID           | Auto-generated, unique, never reused              | No          |
| Full Name         | Required, 1-255 characters                        | No (v1)     |
| Email Address     | Required, valid format, unique (case-insensitive) | No (v1)     |
| Password          | Required, minimum 6 characters, stored hashed     | No (v1)     |
| Role              | Required, "Employee" or "Manager"                 | No (v1)     |
| Registration Date | Auto-generated timestamp                          | No          |

**Email Rules:**

- Valid email format (e.g., user@example.com)
- Unique across all users (case-insensitive)
- Used as login identifier
- Cannot be changed (v1)

**Password Rules:**

- Minimum 6 characters
- Stored securely (hashed, never plain text)
- Cannot be retrieved or displayed
- Cannot be reset (v1)

**Role Rules:**

- Exactly "Employee" or "Manager"
- Cannot be changed (v1)
- Determines feature access

### 6.2 Expense Data

**What Must Be Stored:**

| Data Item    | Rules                                                  | Can Change?             |
| ------------ | ------------------------------------------------------ | ----------------------- |
| Expense ID   | Auto-generated, unique                                 | No                      |
| Created By   | User ID of creator (required, never changes)           | No                      |
| Expense Date | Required, user-provided date                           | Yes (if Draft/Rejected) |
| Amount       | Required, positive number, up to 2 decimal places      | Yes (if Draft/Rejected) |
| Currency     | Required, 3-character code (USD, EUR, GBP, etc.)       | Yes (if Draft/Rejected) |
| Category     | Required, from predefined list                         | Yes (if Draft/Rejected) |
| Description  | Optional, text field                                   | Yes (if Draft/Rejected) |
| Status       | Required, one of: Draft, Submitted, Approved, Rejected | Via workflow only       |
| Created At   | Auto-generated timestamp                               | No                      |
| Submitted At | Auto-generated when submitted                          | No                      |
| Updated At   | Auto-generated, updates on changes                     | Auto                    |

**Approval Data (when approved):**

| Data Item        | Rules                           |
| ---------------- | ------------------------------- |
| Approved By      | User ID of manager who approved |
| Approved At      | Auto-generated timestamp        |
| Approval Comment | Required, text, immutable       |

**Rejection Data (when rejected):**

| Data Item         | Rules                           |
| ----------------- | ------------------------------- |
| Rejected By       | User ID of manager who rejected |
| Rejected At       | Auto-generated timestamp        |
| Rejection Comment | Required, text, immutable       |

### 6.3 Predefined Data

**Expense Categories (minimum set):**

1. Travel
2. Meals
3. Office Supplies
4. Software/Subscriptions
5. Other

(Additional categories can be configured during development)

**Supported Currencies (minimum):**

- USD (US Dollar)
- EUR (Euro)
- GBP (British Pound)

(Additional currencies can be configured during development)

**Allowed Statuses:**

- Draft
- Submitted
- Approved
- Rejected

(No other statuses allowed)

### 6.4 Data Validation

**Amount Validation:**

- Must be a positive number
- Support up to 2 decimal places (e.g., 123.45)
- No maximum limit (v1)

**Date Validation:**

- Must be a valid date
- No restrictions on past/future dates (v1)

**Status Transition Rules:**

- Draft → Submitted (user submits)
- Submitted → Approved (manager approves)
- Submitted → Rejected (manager rejects)
- Rejected → Submitted (user resubmits)
- Approved → (no transitions allowed, final state)

**Invalid transitions must be prevented by the system.**

### 6.5 Data Integrity Rules

**Rule 1: Every expense must be linked to a valid user (creator)**

- System must prevent deletion of users who have expenses

**Rule 2: Immutable historical data**

- Once approved/rejected:
  - Comment cannot be changed
  - Approver/rejector cannot be changed
  - Timestamp cannot be changed
- If approved, expense details cannot be edited
- Preserves audit trail

**Rule 3: Status-based edit permissions**

- Draft: can be edited/deleted by creator
- Submitted: locked, awaiting manager action
- Approved: permanently locked
- Rejected: can be edited by creator and resubmitted

**Rule 4: Self-approval prevention**

- System must check: Is manager approving/rejecting their own expense?
- If yes: deny the action with message "You cannot approve your own expense"

**Rule 5: Required field enforcement**

- Cannot save without required fields:
  - Expense: date, amount, currency, category, status
  - Approval: approval comment
  - Rejection: rejection comment

**Rule 6: Unique email addresses**

- Case-insensitive uniqueness check before creating accounts

---

## 7. Access Control and Security

### 7.1 View Permissions

**Employees Can View:**

- Only their own expenses (all statuses)
- Their own user profile
- Full history of their own expenses

**Managers Can View:**

- All expenses from all employees (all statuses)
- Employee names associated with expenses
- Full history and audit trail of all expenses
- Their own user profile

### 7.2 Edit Permissions

**Employees Can Edit:**

- Their own draft expenses
- Their own rejected expenses (to resubmit)

**Employees Cannot Edit:**

- Submitted expenses (locked)
- Approved expenses (permanently locked)
- Other employees' expenses

**Managers Can Edit:**

- Their own draft expenses
- Their own rejected expenses

**Managers Cannot Edit:**

- Submitted expenses (can only approve/reject)
- Approved expenses (permanently locked)
- Expenses created by other users

**Nobody Can Edit:**

- Approved expenses
- Approval/rejection comments (immutable)
- User profiles (v1)
- System-generated timestamps

### 7.3 Delete Permissions

**Can Be Deleted:**

- Draft expenses (by creator only, with confirmation)

**Cannot Be Deleted:**

- Submitted expenses
- Approved expenses (permanent records)
- Rejected expenses (can be resubmitted)
- User accounts (v1)

### 7.4 Action Permissions

| Action                      | Employee | Manager | Notes                    |
| --------------------------- | -------- | ------- | ------------------------ |
| Create expense              | ✓        | ✓       | For own use              |
| Edit draft expense (own)    | ✓        | ✓       |                          |
| Delete draft expense (own)  | ✓        | ✓       | With confirmation        |
| Submit expense (own)        | ✓        | ✓       |                          |
| View own expenses           | ✓        | ✓       |                          |
| View all expenses           | ✗        | ✓       |                          |
| Filter/search expenses      | ✓        | ✓       | Own vs all, respectively |
| Approve expense (others')   | ✗        | ✓       | With mandatory comment   |
| Reject expense (others')    | ✗        | ✓       | With mandatory comment   |
| Approve/reject own expense  | ✗        | ✗       | Prevented for both roles |
| Edit submitted expense      | ✗        | ✗       | Locked                   |
| Edit approved expense       | ✗        | ✗       | Permanently locked       |
| Edit rejected expense (own) | ✓        | ✓       | To fix and resubmit      |

### 7.5 Security Requirements

**Authentication:**

- All features require login
- Session expires after 24 hours of inactivity
- Logout immediately terminates session

**Authorization:**

- System must enforce permissions on the backend (not just hide UI)
- If Employee tries manager-only action: deny with "Forbidden" error
- If Manager tries to approve own expense: deny with "You cannot approve your own expense"

**Password Security:**

- Store passwords hashed (never plain text)
- Use secure hashing algorithm (e.g., bcrypt)
- Never log or expose passwords

**Session Security:**

- Use secure, httpOnly cookies (prevent JavaScript access)
- HTTPS only
- CSRF protection on all forms

**Data Privacy:**

- Don't reveal whether an email is registered (prevents account enumeration)
- Generic error on login failure: "Invalid email or password"

**Rate Limiting:**

- Prevent brute force login attempts (max 5 attempts per minute per email)

---

## 8. User Experience Requirements

### 8.1 Navigation and Layout

**All Users:**

- Clear, consistent navigation across all pages
- User identity and role visible in header
- "Log Out" button always accessible

**Employee Navigation:**

- "My Expenses" (list view)
- "Create Expense" (button/link)

**Manager Navigation:**

- "All Expenses" or "Review Expenses" (list view)
- "Pending Approvals" (quick filter to submitted expenses)
- "Create Expense" (for their own expenses)

### 8.2 Expense List Views

**Employee View (My Expenses):**

Display for each expense:

- Expense date
- Amount and currency
- Category
- Status (with visual indicator: badge, color, icon)
- Submission date (if submitted)

Sort order: Most recent first (by created/submitted date)

**Manager View (All Expenses):**

Display for each expense:

- All of the above, PLUS:
- Employee name (who created it)

Sort order: "Submitted" expenses first (need attention), then most recent

**Both Views:**

- Click on expense to see full details
- Status clearly indicated with visual cues (badges, colors)
- Empty state message: "No expenses found"

### 8.3 Expense Detail View

**Show All Information:**

- All expense fields (date, amount, currency, category, description)
- Created by (employee name)
- Status
- Created timestamp
- Submitted timestamp (if submitted)
- Approval details (if approved): comment, approver name, timestamp
- Rejection details (if rejected): comment, rejector name, timestamp
- Complete history/timeline of status changes

**Actions Available (context-dependent):**

- "Edit" (if draft or rejected, and user is creator)
- "Delete" (if draft and user is creator)
- "Submit" (if draft and user is creator)
- "Approve" (if submitted and user is manager, not creator)
- "Reject" (if submitted and user is manager, not creator)

### 8.4 Filtering and Searching

**Employee Filters (My Expenses):**

- By status (Draft, Submitted, Approved, Rejected, or "All")
- By date range (from date, to date)
- By category

**Manager Filters (All Expenses):**

- All of the above, PLUS:
- By employee name
- Quick filter: "Pending Approvals" (status = Submitted)

**Filter Behavior:**

- Multiple filters combine (AND logic)
- "Clear Filters" button resets all
- Filter state persists during session
- No results: "No expenses match your filters" with option to clear

### 8.5 Forms and Validation

**Expense Form:**

- Clear labels for all fields
- Obvious distinction between required and optional fields (asterisks or labels)
- Inline validation errors next to fields
- "Save as Draft" button (for new expenses)
- "Submit" button (for drafts ready to submit)
- "Update" button (for editing drafts)
- "Cancel" button (returns to list without saving)

**Approval/Rejection Form:**

- Modal or dialog showing expense details
- Mandatory comment field (text area with adequate space)
- Clear "Approve" or "Reject" button
- "Cancel" option
- Cannot proceed without comment

**Registration/Login Forms:**

- Clean, simple layout
- Password fields mask characters
- Clear error messages
- Links to switch between registration and login

### 8.6 Confirmation Messages

**Success Messages:**

- "Expense saved as draft"
- "Expense submitted for approval"
- "Expense approved"
- "Expense rejected"
- "Expense deleted"
- "Expense updated"
- "Expense resubmitted for approval"
- "Account created successfully"
- "You have been logged out"
- "Welcome, [Full Name]!"

**Error Messages:**

- Field-specific errors shown next to the field
- Generic form errors shown at top of form
- Clear, actionable language

### 8.7 Visual Design Principles

**Status Indicators:**

- Draft: Neutral (gray)
- Submitted: Warning/attention (yellow/orange)
- Approved: Success (green)
- Rejected: Error (red)

**Buttons:**

- Primary actions (Submit, Approve): Prominent, positive color
- Destructive actions (Delete, Reject): Red or cautionary color
- Secondary actions (Cancel): Less prominent

**Clarity:**

- Clear visual hierarchy
- Consistent spacing and layout
- Scannable lists
- Obvious clickable elements

---

## 9. Out of Scope for v1

The following features are **explicitly NOT included** in v1:

### User Management

- ✗ Admin role or user management interface
- ✗ Ability to deactivate or delete users
- ✗ Ability to change user information after registration
- ✗ Password reset or "forgot password" functionality
- ✗ Email verification during registration
- ✗ User profile pages or editing
- ✗ Department or team structure
- ✗ Manager-employee hierarchies
- ✗ Employee IDs, phone numbers, job titles

### Authentication Features

- ✗ "Remember me" checkbox
- ✗ Social login (Google, Microsoft, etc.)
- ✗ Single Sign-On (SSO)
- ✗ Two-factor authentication (2FA)
- ✗ Password strength meter
- ✗ Session history or audit

### Expense Features

- ✗ Receipt file attachments
- ✗ Reimbursement status tracking (paid/unpaid)
- ✗ Payment processing or bank integrations
- ✗ Multi-level approval workflows
- ✗ Automatic approval rules
- ✗ Spending limits per employee or category
- ✗ Budget tracking or allocation
- ✗ Project codes or cost centers
- ✗ Recurring expenses

### Notifications

- ✗ Email notifications for status changes
- ✗ In-app notifications
- ✗ Reminders for pending approvals

### Reporting and Export

- ✗ Reports or dashboards
- ✗ Data export (CSV, Excel, PDF)
- ✗ Analytics or charts
- ✗ Bulk operations

### Other

- ✗ Mobile applications
- ✗ Advanced search (full-text search)
- ✗ Comments or discussion threads on expenses
- ✗ Attachments or documents
- ✗ Integration with accounting software

**Note:** These features may be considered for future versions based on business needs.

---

## 10. Acceptance Criteria

### 10.1 User Registration and Authentication

**Must:**
✓ Allow any person to create an account with email, password, full name, and role  
✓ Validate all inputs before creating account  
✓ Prevent duplicate email addresses (case-insensitive)  
✓ Require minimum 6-character password  
✓ Store passwords securely (hashed, never plain text)  
✓ Automatically log in user after successful registration  
✓ Allow login with email and password (case-insensitive email)  
✓ Keep users logged in for 24 hours  
✓ Provide "Log Out" functionality  
✓ Display user's name and role while logged in  
✓ Show generic error for invalid login ("Invalid email or password")

### 10.2 Expense Creation and Management

**Must:**
✓ Allow employees and managers to create expenses  
✓ Require date, amount, currency, and category  
✓ Allow optional description  
✓ Save expenses as "Draft" status  
✓ Allow editing of draft expenses by creator  
✓ Allow deletion of draft expenses by creator (with confirmation)  
✓ Validate all required fields before saving

### 10.3 Expense Submission

**Must:**
✓ Allow creator to submit draft expenses  
✓ Change status from "Draft" to "Submitted"  
✓ Record submission timestamp  
✓ Lock expense from editing after submission  
✓ Make submitted expense visible to all managers

### 10.4 Expense Approval

**Must:**
✓ Allow managers to approve submitted expenses  
✓ Prevent managers from approving their own expenses  
✓ Require mandatory approval comment  
✓ Change status from "Submitted" to "Approved"  
✓ Record approver, approval comment, and timestamp  
✓ Permanently lock approved expenses from editing  
✓ Display approval details to employee

### 10.5 Expense Rejection

**Must:**
✓ Allow managers to reject submitted expenses  
✓ Prevent managers from rejecting their own expenses  
✓ Require mandatory rejection comment  
✓ Change status from "Submitted" to "Rejected"  
✓ Record rejector, rejection comment, and timestamp  
✓ Allow employee to edit rejected expense  
✓ Display rejection details clearly to employee

### 10.6 Expense Resubmission

**Must:**
✓ Allow creator to edit rejected expenses  
✓ Preserve original rejection comment in history  
✓ Allow resubmission after editing  
✓ Change status from "Rejected" to "Submitted" on resubmission  
✓ Record new submission timestamp

### 10.7 Viewing and Filtering

**Must:**
✓ Employees see only their own expenses  
✓ Managers see all expenses from all employees  
✓ Display expense summary (date, amount, currency, category, status)  
✓ Allow filtering by status, date range, and category  
✓ Managers can filter by employee name  
✓ Quick filter for "Pending Approvals" (submitted expenses)  
✓ Show full expense details including history  
✓ Display complete audit trail (creation, submission, approval/rejection)

### 10.8 Access Control

**Must:**
✓ Enforce role-based permissions on all actions  
✓ Deny unauthorized access with appropriate error messages  
✓ Prevent users from approving/rejecting their own expenses  
✓ Prevent editing of submitted and approved expenses  
✓ Allow only creator to edit draft and rejected expenses  
✓ Prevent deletion of submitted, approved, and rejected expenses

### 10.9 Data Integrity

**Must:**
✓ Maintain immutable approval/rejection comments  
✓ Preserve complete history of status changes  
✓ Record timestamps automatically for all events  
✓ Link expenses to creators (users)  
✓ Link approvals/rejections to managers  
✓ Prevent invalid status transitions  
✓ Enforce required fields  
✓ Prevent duplicate email addresses

### 10.10 Security

**Must:**
✓ Require authentication for all features  
✓ Expire sessions after 24 hours of inactivity  
✓ Use secure password storage (hashing)  
✓ Use secure session management (httpOnly, secure cookies)  
✓ Implement CSRF protection  
✓ Rate limit login attempts  
✓ Never expose passwords in any form  
✓ Use generic error messages to prevent account enumeration

---

## 11. User Stories Reference

This PRD is supported by the following detailed user stories:

### Expense Management Stories

- **US-001:** Create expense as draft
- **US-002:** Edit draft expense
- **US-003:** Delete draft expense
- **US-004:** Submit expense for approval
- **US-005:** View my expenses (Employee)
- **US-006:** Filter and search my expenses (Employee)
- **US-007:** View all expenses (Manager)
- **US-008:** Filter and search expenses (Manager)
- **US-009:** Approve expense
- **US-010:** Reject expense
- **US-011:** Edit and resubmit rejected expense
- **US-012:** View expense history and audit trail

### User Management Stories

- **US-013:** User registration
- **US-014:** User login
- **US-015:** Role-based access control

**Note:** Each user story contains detailed acceptance criteria in Given/When/Then format.

---

## 12. Performance Requirements

### 12.1 Response Time

- User login: < 2 seconds
- Expense list loading: < 2 seconds
- Expense detail view: < 1 second
- Expense creation/editing: < 1 second to save
- Approval/rejection: < 1 second to process

### 12.2 Capacity

- Support up to 100 concurrent users
- Handle 100 initial users
- Estimated 50-200 expenses per month
- 5-year data retention
- Approximately 12,000 expense records over 5 years

---

## 13. Open Questions

None at this time. All customer questions have been answered and requirements clarified.

---

## 14. Future Considerations

When the company has more resources, consider:

- Admin role for managing users
- User deactivation for employees who leave
- User profile editing
- Password reset functionality
- Email notifications for status changes
- Receipt file attachments
- Multi-level approval workflows
- Department and team structure
- Budget tracking and spending limits
- Reporting and analytics
- Integration with accounting systems
- Mobile applications

---

## Appendix A: Key User Flows

### Flow 1: New User Registration and First Expense

```
1. User navigates to system → sees login page
2. Clicks "Register"
3. Fills form:  name, email, password, role (Manager)
4. Clicks "Register" → account created
5. Automatically logged in → redirected to expenses page
6. Clicks "Create Expense"
7. Fills: date, amount (100. 00), currency (USD), category (Meals)
8. Clicks "Save as Draft" → expense saved
9. Reviews expense → clicks "Submit"
10. Expense now "Submitted", awaiting manager review
```

### Flow 2: Manager Reviews and Approves Expense

```
1. Manager logs in → sees "All Expenses" view
2. Sees list with "Submitted" expense highlighted
3. Clicks on expense → sees full details
4. Clicks "Approve"
5. Dialog opens → enters comment:  "Approved, looks good"
6. Clicks "Confirm"
7. Expense status → "Approved"
8. Employee sees status change with approval comment
```

### Flow 3: Manager Rejects Expense, Employee Fixes and Resubmits

```
1. Manager reviews submitted expense
2. Clicks "Reject"
3. Enters comment: "Missing receipt details in description"
4. Confirms rejection → status "Rejected"
5. Employee views expense → sees rejection comment
6. Clicks "Edit"
7. Updates description field with receipt details
8. Clicks "Resubmit"
9. Expense status → "Submitted" again
10.  Appears in manager's review queue again
11. Manager approves on second review
```

### Flow 4: Employee Filters Their Expenses

```
1. Employee logs in → sees "My Expenses"
2. Has 20 total expenses
3. Selects filter:  Status = "Approved"
4. Selects date range: Last 3 months
5. List updates → shows only approved expenses from last 3 months
6. Clicks "Clear Filters" → sees all 20 expenses again
```

---

## Document History

| Version | Date       | Changes                          | Author             |
| ------- | ---------- | -------------------------------- | ------------------ |
| 1.0     | 2026-01-01 | Initial consolidated PRD created | Product Management |

---
