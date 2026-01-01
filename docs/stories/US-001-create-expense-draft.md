# US-001: Create Expense as Draft

## User Story
**As an** employee  
**I want to** create a new expense record and save it as a draft  
**So that** I can prepare my expense information before submitting it for approval

---

## Description
Employees need to record expense information (date, amount, currency, category, and optional description) and save it without immediately submitting it for approval.  This allows them to prepare expenses when they have time and submit them later. 

---

## Acceptance Criteria

### AC-1: Access to create expense
- **Given** I am logged in as an employee or manager
- **When** I navigate to the expenses section
- **Then** I see a clearly visible "Create New Expense" button or link

### AC-2: Expense form fields
- **Given** I click "Create New Expense"
- **When** the form loads
- **Then** I see the following fields:
  - Date of expense (date picker)
  - Amount (numeric input)
  - Currency (dropdown with options:  USD, EUR, GBP, and others as configured)
  - Category (dropdown with options: Travel, Meals, Office Supplies, Software/Subscriptions, Other)
  - Description (text area, optional)

### AC-3: Mandatory field validation
- **Given** I am filling out the expense form
- **When** I try to save without completing mandatory fields (date, amount, currency, category)
- **Then** I see clear error messages indicating which fields are required
- **And** the expense is not saved

### AC-4: Amount validation
- **Given** I am entering an amount
- **When** I enter a negative number or zero
- **Then** I see an error message "Amount must be a positive number"
- **And** the expense is not saved

### AC-5: Save as draft
- **Given** I have filled in all mandatory fields correctly
- **When** I click "Save as Draft"
- **Then** the expense is saved with status "Draft"
- **And** I am redirected to my expenses list
- **And** I see a confirmation message "Expense saved as draft"
- **And** the created timestamp is automatically recorded

### AC-6: Draft is editable
- **Given** I have saved an expense as draft
- **When** I view my expenses list
- **Then** the draft expense appears with status "Draft"
- **And** I can open it to edit later

### AC-7: Description is optional
- **Given** I am creating a new expense
- **When** I fill in all mandatory fields but leave description empty
- **Then** I can successfully save the expense as draft

### AC-8: Expense is linked to creator
- **Given** I have successfully saved an expense as draft
- **When** the expense is stored in the system
- **Then** the expense is automatically linked to my user ID (creator)
- **And** this link cannot be changed

---

## Technical Notes
- Status should default to "Draft" when creating
- Created timestamp should be automatically recorded (Created At)
- Updated timestamp should be automatically recorded (Updated At)
- The expense should be associated with the logged-in user's ID (creator)
- Amount should support up to 2 decimal places

---

## UI/UX Considerations
- Form should be clean and minimal
- Clear labels for all fields
- Obvious distinction between required (marked with asterisk *) and optional fields
- Confirmation message should be visible but not intrusive
- Category dropdown should list options in a logical order

---

## Dependencies
- User authentication system must be in place (US-013, US-014)
- Predefined categories must be configured in the system
- Predefined currencies must be configured in the system