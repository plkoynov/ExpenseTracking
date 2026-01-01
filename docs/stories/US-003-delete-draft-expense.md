# US-003: Delete Draft Expense

## User Story
**As an** employee  
**I want to** delete an expense that is still in draft status  
**So that** I can remove expenses I no longer need to submit

---

## Description
Employees may create draft expenses that are no longer needed (duplicate entries, canceled expenses, mistakes). They should be able to permanently remove these drafts before submission.

---

## Acceptance Criteria

### AC-1: Delete option for drafts
- **Given** I am viewing my expenses list
- **When** I see expenses with status "Draft"
- **Then** each draft has a visible "Delete" action button/link

### AC-2: Deletion confirmation
- **Given** I click "Delete" on a draft expense
- **When** the delete action is triggered
- **Then** I see a confirmation dialog asking "Are you sure you want to delete this expense?"
- **And** I have options to "Confirm" or "Cancel"

### AC-3: Confirm deletion
- **Given** I see the deletion confirmation dialog
- **When** I click "Confirm"
- **Then** the draft expense is permanently removed from the system
- **And** I see a confirmation message "Expense deleted"
- **And** the expense no longer appears in my expenses list

### AC-4: Cancel deletion
- **Given** I see the deletion confirmation dialog
- **When** I click "Cancel"
- **Then** the dialog closes
- **And** the expense is NOT deleted
- **And** I remain on my expenses list

### AC-5: Only drafts can be deleted
- **Given** I have an expense with status "Submitted", "Approved", or "Rejected"
- **When** I view that expense
- **Then** I do NOT see a "Delete" button
- **And** I cannot delete the expense

---

## Technical Notes
- Hard delete from database is acceptable for drafts (no audit trail needed for drafts)
- Only the owner (creator) of the draft can delete it
- Deletion is permanent and cannot be undone

---

## UI/UX Considerations
- Delete button should be visually distinct (e.g., red color) to indicate destructive action
- Confirmation dialog should be clear and not easy to dismiss accidentally
- Confirmation message should be brief and clear

---

## Dependencies
- US-001 (Create expense as draft) must be completed