# US-014: User Login

## User Story
**As a** registered user  
**I want to** log in to the expense management system  
**So that** I can access my expenses and perform my role-specific tasks

---

## Description
Users who have registered need to authenticate themselves to access the system. Login is done using email and password. 

---

## Acceptance Criteria

### AC-1: Access login page
- **Given** I am not logged in
- **When** I navigate to the system URL
- **Then** I see a login form or a "Log In" link that takes me to the login page

### AC-2: Login form fields
- **Given** I am on the login page
- **When** the page loads
- **Then** I see the following fields:
  - Email Address (text/email input, required)
  - Password (password input, required)
  - "Log In" button

### AC-3: Successful login
- **Given** I have a registered account
- **When** I enter my correct email and password
- **And** I click "Log In"
- **Then** I am authenticated
- **And** I am redirected to the main expenses page
- **And** I can see my role-appropriate view (my expenses if Employee, all expenses if Manager)

### AC-4: Failed login - incorrect password
- **Given** I enter a registered email address
- **When** I enter an incorrect password
- **And** I click "Log In"
- **Then** I see an error message "Invalid email or password"
- **And** I remain on the login page
- **And** the form is cleared

### AC-5: Failed login - unregistered email
- **Given** I enter an email address that is not registered
- **When** I enter any password
- **And** I click "Log In"
- **Then** I see an error message "Invalid email or password"
- **And** I remain on the login page

### AC-6: Required field validation
- **Given** I am on the login page
- **When** I try to submit the form with empty email or password
- **Then** I see validation messages "Email is required" and/or "Password is required"
- **And** login does not proceed

### AC-7: Case-insensitive email login
- **Given** I registered with email "john. doe@company.com"
- **When** I log in with "John. Doe@Company.com" or "JOHN.DOE@COMPANY. COM"
- **Then** I am successfully logged in (email is case-insensitive)

### AC-8: Link to registration page
- **Given** I am on the login page
- **When** I don't have an account yet
- **Then** I see a link "Don't have an account?  Register"
- **And** clicking it takes me to the registration page

### AC-9: Session persistence
- **Given** I have successfully logged in
- **When** I navigate between pages within the system
- **Then** I remain logged in
- **And** I do not need to re-authenticate

### AC-10: Logout functionality
- **Given** I am logged in
- **When** I click "Log Out" (from header/menu)
- **Then** I am logged out
- **And** my session is terminated
- **And** I am redirected to the login page
- **And** I see a message "You have been logged out"

---

## Technical Notes
- Email lookup should be case-insensitive (normalize to lowercase)
- Password verification must use secure hashing comparison (e.g., bcrypt. compare)
- Error messages should be generic to prevent user enumeration ("Invalid email or password" instead of "Email not found")
- Session management using secure cookies or tokens
- Session should expire after reasonable inactivity period (e.g., 24 hours)

---

## UI/UX Considerations
- Simple, clean login form
- Password field should mask characters
- Error message should be clear but not reveal whether email exists
- "Log Out" button/link should be visible in header/navigation when logged in
- Consider showing user's name in header when logged in

---

## Security Notes
- Implement rate limiting to prevent brute force attacks (e.g., max 5 attempts per minute per email)
- Use HTTPS for all authentication requests
- Implement CSRF protection
- Use secure, httpOnly, sameSite cookies for session management
- Session tokens should be cryptographically random

---

## Dependencies
- US-013 (User Registration) must be completed