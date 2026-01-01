# US-011: Edit and Resubmit Rejected Expense

## User Story
**As an** employee  
**I want to** edit a rejected expense and resubmit it  
**So that** I can correct the issues and get it approved

---

## Description
When a manager rejects an expense, the employee needs to be able to fix the issues mentioned in the rejection comment, update the expense, and resubmit it for a new review. 

---

## Acceptance Criteria

### AC-1: Edit option for rejected expenses
- **Given** I am viewing my expenses list
- **When** I see an expense with status "Rejected"
- **Then** I see an "Edit" button/link for that expense

### AC-2: View rejection reason before editing
- **Given** I have a rejected expense
- **When** I view the expense details
- **Then** I clearly see: 
  - Status: "Rejected"
  - Rejection comment from the manager
  - Manager who rejected it
  - Rejection timestamp
- **And** I see an "Edit" button

### AC-3: Edit rejected expense
- **Given** I click "Edit" on a rejected expense
- **When** the form loads
- **Then** all expense fields are pre-populated with the previous values
- **And** the rejection comment remains visible for reference
- **And** I can modify any field (date, amount, currency, category, description)

### AC-4: Save changes to rejected expense
- **Given** I am editing a rejected expense
- **When** I modify fields and click "Save"
- **Then** the expense is saved with the updated values
- **And** the status remains "Rejected" (not automatically resubmitted)
- **And** I see a confirmation "Expense updated"

### AC-5: Resubmit rejected expense
- **Given** I have edited a rejected expense
- **When** I click "Submit" (or "Resubmit")
- **Then** the expense status changes from "Rejected" to "Submitted"
- **And** a new submission timestamp is recorded
- **And** the previous rejection comment is preserved in history
- **And** I see a confirmation "Expense resubmitted for approval"

### AC-6: Previous rejection history preserved
- **Given** I have resubmitted a previously rejected expense
- **When** a manager views the expense
- **Then** they can see:
  - Current status: "Submitted"
  - Previous rejection comment and timestamp
  - History of status changes

### AC-7: Validation on resubmission
- **Given** I am editing a rejected expense
- **When** I try to resubmit without filling mandatory fields
- **Then** I see validation errors
- **And** the expense is not resubmitted

---

## Technical Notes
- Rejection history should be preserved (do not overwrite previous rejection data)
- New submission timestamp should be recorded on resubmission
- Status transition: Rejected → Submitted (when resubmitted)
- Consider storing revision history if multiple reject/edit cycles occur

---

## UI/UX Considerations
- Rejection comment should be clearly visible during editing to guide corrections
- Clear distinction between "Save" (keep as rejected) and "Resubmit" (send back for review)
- Visual indication that this is a resubmission (e.g., "Resubmit" instead of "Submit")
- History/timeline view would be helpful to show previous rejections

---

## Dependencies
- US-010 (Reject expense) must be completed