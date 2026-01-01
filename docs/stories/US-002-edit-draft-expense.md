# US-002: Edit Draft Expense

## User Story
**As an** employee  
**I want to** edit an expense that is still in draft status  
**So that** I can correct mistakes or update information before submitting

---

## Description
Before submitting an expense for approval, employees should be able to make changes to any draft expenses they have created. This ensures accuracy and reduces the need for rejection due to simple errors.

---

## Acceptance Criteria

### AC-1: Identify editable drafts
- **Given** I am viewing my expenses list
- **When** I see expenses with status "Draft"
- **Then** each draft has a visible "Edit" action button/link

### AC-2: Open draft for editing
- **Given** I have an expense in draft status
- **When** I click "Edit" on that expense
- **Then** the expense form opens with all previously entered data pre-populated

### AC-3: Modify draft fields
- **Given** I have opened a draft expense for editing
- **When** I change any field values (date, amount, currency, category, description)
- **Then** I can save the updated values
- **And** the modified data is persisted

### AC-4: Validation on edit
- **Given** I am editing a draft expense
- **When** I remove a mandatory field value (date, amount, currency, category)
- **Then** I see validation error messages
- **And** I cannot save until all mandatory fields are filled

### AC-5: Only drafts are editable
- **Given** I have an expense with status "Submitted", "Approved", or "Rejected"
- **When** I view that expense
- **Then** I do NOT see an "Edit" button
- **And** the expense details are read-only

### AC-6: Update confirmation
- **Given** I have successfully edited and saved a draft expense
- **When** the save completes
- **Then** I see a confirmation message "Expense updated"
- **And** I am returned to my expenses list
- **And** the expense still shows status "Draft"

---

## Technical Notes
- Only the owner (creator) of the expense can edit their own draft
- Status must remain "Draft" after editing
- Last modified timestamp should be updated

---

## UI/UX Considerations
- Pre-populated form should clearly indicate this is editing, not creating
- Save button might say "Update" instead of "Save as Draft" to indicate editing
- Cancel action should return to expenses list without saving changes

---

## Dependencies
- US-001 (Create expense as draft) must be completed