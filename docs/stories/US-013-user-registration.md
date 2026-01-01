# US-013: User Registration

## User Story
**As a** new user  
**I want to** register for an account in the expense management system  
**So that** I can start using the system as an employee or manager

---

## Description
Since this is an internal system without admin-managed user provisioning initially, users need to be able to self-register with basic information. During registration, they choose their role (Employee or Manager).

---

## Acceptance Criteria

### AC-1: Access registration page
- **Given** I am not logged in
- **When** I navigate to the system URL
- **Then** I see a "Register" or "Sign Up" link/button
- **And** clicking it takes me to the registration form

### AC-2: Registration form fields
- **Given** I am on the registration page
- **When** the page loads
- **Then** I see the following fields:
  - Full Name (text input, required)
  - Email Address (email input, required)
  - Password (password input, required)
  - Confirm Password (password input, required)
  - Role (radio buttons or dropdown:  "Employee" or "Manager", required)

### AC-3: Email validation
- **Given** I am filling out the registration form
- **When** I enter an email address
- **Then** the system validates it is a properly formatted email address
- **And** if invalid format, I see an error message "Please enter a valid email address"

### AC-4: Email uniqueness
- **Given** I am submitting the registration form
- **When** I enter an email that is already registered in the system
- **Then** I see an error message "This email address is already registered"
- **And** registration does not proceed

### AC-5: Password confirmation match
- **Given** I am filling out the registration form
- **When** I enter different values in "Password" and "Confirm Password"
- **Then** I see an error message "Passwords do not match"
- **And** registration does not proceed

### AC-6: Password complexity requirement
- **Given** I am entering a password
- **When** I enter a password with fewer than 6 characters
- **Then** I see an error message "Password must be at least 6 characters"
- **And** registration does not proceed

### AC-7: Role selection required
- **Given** I am filling out the registration form
- **When** I do not select a role (Employee or Manager)
- **Then** I see an error message "Please select your role"
- **And** registration does not proceed

### AC-8:  Successful registration
- **Given** I have filled in all required fields correctly
- **When** I click "Register" or "Sign Up"
- **Then** my account is created in the system
- **And** my password is securely hashed and stored
- **And** I am automatically logged in
- **And** I am redirected to the main expenses page
- **And** I see a welcome message "Welcome, [Full Name]!"

### AC-9: Link to login page
- **Given** I am on the registration page
- **When** I already have an account
- **Then** I see a link "Already have an account? Log in"
- **And** clicking it takes me to the login page

---

## Technical Notes
- Email should be stored in lowercase and used as unique identifier
- Password must be hashed using a secure hashing algorithm (e.g., bcrypt, Argon2)
- Never store passwords in plain text
- Role should be stored as ENUM or string:  "Employee" or "Manager"
- Email validation should check format (regex or built-in validator)
- Minimum password length: 6 characters (as per customer:  minimal complexity for internal system)

---

## UI/UX Considerations
- Clear and simple form layout
- Inline validation errors displayed next to fields
- Password field should mask characters
- Role selection should be clear (radio buttons with labels "Employee" and "Manager")
- Registration button should be prominent
- Clear indication of required fields (asterisks or labels)

---

## Dependencies
- None (this is the entry point to the system)

---

## Security Notes
- Implement CSRF protection on registration form
- Rate limiting to prevent automated registration abuse
- Consider email format validation (allow only company domain if needed in future)