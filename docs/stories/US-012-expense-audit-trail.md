# US-012: View Expense History and Audit Trail

## User Story
**As an** employee or manager  
**I want to** see the complete history of an expense  
**So that** I understand all status changes, approvals, rejections, and comments

---

## Description
Transparency and traceability are critical to the system. All users should be able to see the full history of an expense:  when it was created, submitted, approved/rejected, by whom, and with what comments.

---

## Acceptance Criteria

### AC-1: View creation information
- **Given** I am viewing any expense details
- **When** the details page loads
- **Then** I see: 
  - Created by (employee name)
  - Created date/timestamp (Created At)

### AC-2: View submission information
- **Given** I am viewing an expense that has been submitted (status: Submitted, Approved, or Rejected)
- **When** the details page loads
- **Then** I see:
  - Submitted date/timestamp (Submitted At)

### AC-3: View approval information
- **Given** I am viewing an expense with status "Approved"
- **When** the details page loads
- **Then** I see:
  - Status: "Approved" (with green success indicator)
  - Approval comment (immutable)
  - Approved by (manager name)
  - Approved date/timestamp (Approved At)

### AC-4: View rejection information
- **Given** I am viewing an expense with status "Rejected"
- **When** the details page loads
- **Then** I see:
  - Status: "Rejected" (with red error indicator)
  - Rejection comment (immutable, prominently displayed)
  - Rejected by (manager name)
  - Rejected date/timestamp (Rejected At)

### AC-5: View resubmission history
- **Given** an expense has been rejected and then resubmitted
- **When** I view the expense details
- **Then** I see a timeline or history showing:
  - Initial creation (creator, timestamp)
  - Initial submission (timestamp)
  - Rejection (rejector name, rejection comment, timestamp)
  - Resubmission (new submitted timestamp)
  - Current status

### AC-6: View multiple rejection cycles
- **Given** an expense has been rejected and resubmitted multiple times
- **When** I view the expense history
- **Then** I see all rejection events in chronological order
- **And** each rejection shows:  rejector name, rejection comment, timestamp
- **And** each resubmission shows: resubmission timestamp

### AC-7: Comments are immutable and visible
- **Given** an expense has approval or rejection comments
- **When** I view the expense
- **Then** all comments are visible and clearly displayed
- **And** each comment shows who wrote it and when
- **And** comments cannot be edited or deleted (no edit buttons visible)

### AC-8: Managers and employees see the same history
- **Given** an expense has a complete history
- **When** both the employee (creator) and a manager view the expense
- **Then** they both see the same audit trail information
- **And** all timestamps, comments, and events are identical

### AC-9: History displayed in chronological order
- **Given** an expense has multiple events (creation, submission, rejection, resubmission, approval)
- **When** I view the history/timeline
- **Then** events are displayed in chronological order (oldest to newest, or as a reverse timeline)
- **And** it is easy to follow the progression of the expense

### AC-10: Updated timestamp shown
- **Given** an expense has been edited (draft or rejected status)
- **When** I view the expense details
- **Then** I see the "Last Updated" timestamp (Updated At)
- **And** it reflects the most recent modification

---

## Technical Notes
- All status changes should be logged with timestamp and user ID
- Comments should be stored immutably (no UPDATE allowed)
- Consider a separate audit/history table for complex scenarios with multiple rejections
- Display history in chronological order
- Timestamps to track: 
  - created_at:  when expense was first created
  - submitted_at:  when expense was submitted (or resubmitted)
  - approved_at: when expense was approved
  - rejected_at: when expense was rejected
  - updated_at: when expense was last modified

---

## UI/UX Considerations
- History/timeline should be easy to scan
- Use visual indicators (icons, colors) for different event types: 
  - Creation: neutral icon
  - Submission: arrow/send icon
  - Approval: green checkmark
  - Rejection:  red X
  - Resubmission: refresh/retry icon
- Comments should be clearly attributed and timestamped
- Consider a collapsible "History" or "Timeline" section if it gets long
- Highlight the current status prominently
- Use relative timestamps where helpful ("2 days ago") with absolute timestamps on hover

---

## Dependencies
- US-004 (Submit expense)
- US-009 (Approve expense)
- US-010 (Reject expense)
- US-011 (Edit and resubmit rejected expense)