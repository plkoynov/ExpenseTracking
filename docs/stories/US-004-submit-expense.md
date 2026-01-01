# US-004: Submit Expense for Approval

## User Story
**As an** employee  
**I want to** submit my draft expense for manager approval  
**So that** it can be reviewed and I can get reimbursed

---

## Description
Once an employee has created and reviewed a draft expense, they need to formally submit it for manager review.  After submission, the expense should no longer be editable by the employee and should appear in the manager's review queue.

---

## Acceptance Criteria

### AC-1: Submit option for drafts
- **Given** I am viewing my expenses list
- **When** I see an expense with status "Draft"
- **Then** I see a "Submit" action button/link

### AC-2: Submit validation
- **Given** I click "Submit" on a draft expense
- **When** the submission is triggered
- **Then** the system validates all mandatory fields are present (date, amount, currency, category)
- **And** if validation passes, the expense is submitted

### AC-3: Status change on submission
- **Given** I successfully submit a draft expense
- **When** the submission completes
- **Then** the expense status changes from "Draft" to "Submitted"
- **And** I see a confirmation message "Expense submitted for approval"
- **And** the submission timestamp is recorded

### AC-4: Submitted expense is locked
- **Given** I have submitted an expense
- **When** I view that expense in my list
- **Then** the status shows "Submitted"
- **And** I do NOT see "Edit" or "Delete" buttons
- **And** the expense details are read-only for me

### AC-5: Submitted expense visible to managers
- **Given** I have submitted an expense
- **When** a manager views the expenses list
- **Then** my submitted expense appears in their list with status "Submitted"

### AC-6: Cannot submit non-draft expenses
- **Given** I have an expense with status "Submitted", "Approved", or "Rejected"
- **When** I view that expense
- **Then** I do NOT see a "Submit" button

---

## Technical Notes
- Submitted timestamp should be recorded
- Status transition:  Draft → Submitted only
- Once submitted, employee cannot modify the expense
- Submitted expenses should be visible to all managers

---

## UI/UX Considerations
- Submit button should be prominent and clearly labeled
- After submission, user should be returned to their expenses list
- Confirmation message should be clear and reassuring
- Status badge should visually distinguish "Submitted" from "Draft"

---

## Dependencies
- US-001 (Create expense as draft) must be completed