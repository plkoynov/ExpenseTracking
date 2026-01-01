# Development Backlog:  Expense Management System

## Sprint Planning Guide

This backlog is ordered by **implementation priority**. Stories at the top are foundational and must be completed before later stories can be implemented.

---

## Backlog

| Priority | Story ID | Story Name                                    | Status      | Dependencies                    | Sprint Suggestion |
|----------|----------|-----------------------------------------------|-------------|---------------------------------|-------------------|
| 1        | US-013   | User Registration                             | Not Started | None (foundational)             | Sprint 1          |
| 2        | US-014   | User Login                                    | Not Started | US-013                          | Sprint 1          |
| 3        | US-015   | Role-Based Access Control                     | Not Started | US-013, US-014                  | Sprint 1          |
| 4        | US-001   | Create Expense as Draft                       | Not Started | US-013, US-014, US-015          | Sprint 2          |
| 5        | US-002   | Edit Draft Expense                            | Not Started | US-001                          | Sprint 2          |
| 6        | US-003   | Delete Draft Expense                          | Not Started | US-001                          | Sprint 2          |
| 7        | US-005   | View My Expenses (Employee)                   | Not Started | US-001                          | Sprint 2          |
| 8        | US-004   | Submit Expense for Approval                   | Not Started | US-001, US-002, US-005          | Sprint 3          |
| 9        | US-007   | View All Expenses (Manager)                   | Not Started | US-001, US-004, US-015          | Sprint 3          |
| 10       | US-009   | Approve Expense                               | Not Started | US-004, US-007                  | Sprint 3          |
| 11       | US-010   | Reject Expense                                | Not Started | US-004, US-007                  | Sprint 3          |
| 12       | US-011   | Edit and Resubmit Rejected Expense            | Not Started | US-002, US-010                  | Sprint 4          |
| 13       | US-012   | View Expense History and Audit Trail          | Not Started | US-004, US-009, US-010, US-011  | Sprint 4          |
| 14       | US-006   | Filter and Search My Expenses (Employee)      | Not Started | US-005                          | Sprint 4          |
| 15       | US-008   | Filter and Search Expenses (Manager)          | Not Started | US-007                          | Sprint 4          |

---

## Implementation Notes

### Sprint 1: Foundation (User Management)
**Goal:** Users can register, log in, and the system recognizes their role.

**Stories:**
- US-013: User Registration
- US-014: User Login
- US-015: Role-Based Access Control

**Deliverable:** A working authentication system where users can create accounts, log in, and see role-appropriate navigation.

**Critical Path:** This sprint blocks all other work.  Must be completed first.

---

### Sprint 2: Basic Expense Management (Employee View)
**Goal:** Employees can create, edit, delete, and view their own draft expenses.

**Stories:**
- US-001: Create Expense as Draft
- US-002: Edit Draft Expense
- US-003: Delete Draft Expense
- US-005: View My Expenses (Employee)

**Deliverable:** Employees can manage their expenses in draft form and see a list of their expenses. 

**Note:** At the end of this sprint, expenses cannot yet be submitted or approved.  This is intentional — we're building incrementally.

---

### Sprint 3: Approval Workflow (Manager View)
**Goal:** Complete the core workflow — submit, review, approve, reject.

**Stories:**
- US-004: Submit Expense for Approval
- US-007: View All Expenses (Manager)
- US-009: Approve Expense
- US-010: Reject Expense

**Deliverable:** Full end-to-end workflow from expense creation → submission → manager review → approval/rejection.

**Critical Path:** This completes the Minimum Viable Product (MVP). After this sprint, the system is usable for the core use case.

---

### Sprint 4:  Enhancements (Filters, History, Resubmission)
**Goal:** Add quality-of-life features and complete the rejected expense cycle.

**Stories:**
- US-011: Edit and Resubmit Rejected Expense
- US-012: View Expense History and Audit Trail
- US-006: Filter and Search My Expenses (Employee)
- US-008: Filter and Search Expenses (Manager)

**Deliverable:** Full-featured system with filtering, complete audit trail, and the ability to fix and resubmit rejected expenses. 

**Note:** These stories enhance usability but are not critical for the core workflow. Can be deprioritized if timeline is tight.

---

## Definition of Done (for each story)

A story is considered **Done** when: 

- ✅ All acceptance criteria are implemented and pass
- ✅ Code is reviewed and merged
- ✅ Unit tests written and passing (if applicable)
- ✅ Manual testing completed
- ✅ Works in both Employee and Manager contexts (where applicable)
- ✅ No critical bugs
- ✅ Security requirements met (authentication, authorization, data validation)
- ✅ UI is consistent with design principles (status colors, visual indicators, etc.)

---

## Story Dependencies Diagram

```
US-013 (Register) ──┬──> US-014 (Login) ──> US-015 (Roles) ──┬──> US-001 (Create Draft) ──┬──> US-002 (Edit Draft)
                    │                                         │                            │
                    └─────────────────────────────────────────┘                            ├──> US-003 (Delete Draft)
                                                                                            │
                                                                                            ├──> US-005 (View My Expenses) ──> US-006 (Filter - Employee)
                                                                                            │
                                                                                            └──> US-004 (Submit) ──┬──> US-007 (View All) ──> US-008 (Filter - Manager)
                                                                                                                   │
                                                                                                                   ├──> US-009 (Approve) ──┬──> US-012 (Audit Trail)
                                                                                                                   │                       │
                                                                                                                   └──> US-010 (Reject) ───┴──> US-011 (Resubmit)
```

---

## MVP Definition

**Minimum Viable Product = Sprint 1 + Sprint 2 + Sprint 3**

After Sprint 3, the system can:
- ✅ Users register and log in
- ✅ Employees create and submit expenses
- ✅ Managers review and approve/reject expenses
- ✅ Everyone sees current status
- ✅ Audit trail (who approved/rejected, when, why)

**Sprint 4 is post-MVP enhancement** (filtering, resubmission, detailed history view).

---

## Tracking Template

### How to Use This Backlog

1. **Start with Priority 1** (US-013) and work sequentially
2. **Update Status** as work progresses:  
   - `Not Started` → `In Progress` → `In Review` → `Done`
3. **Don't skip ahead** — dependencies are real and will cause rework
4. **Mark stories "Done"** only when Definition of Done is met
5. **Review after each sprint** — adjust if needed

### Status Values

- **Not Started**: No work has begun
- **In Progress**:  Actively being developed
- **In Review**: Code complete, awaiting review/testing
- **Done**: Meets Definition of Done, merged, tested
- **Blocked**: Cannot proceed due to dependency or issue

---

## Risk Mitigation

### High-Risk Stories (require extra attention)

| Story ID | Risk                                          | Mitigation                                                |
|----------|-----------------------------------------------|-----------------------------------------------------------|
| US-013   | Foundation for everything                     | Allocate senior developer, thorough testing               |
| US-014   | Security critical (authentication)            | Security review, password hashing validation              |
| US-015   | Access control bugs could expose data         | Comprehensive testing of all permission scenarios         |
| US-009   | Self-approval prevention must be bulletproof  | Write specific tests for edge cases                       |
| US-010   | Self-rejection prevention must be bulletproof | Write specific tests for edge cases                       |
| US-012   | Audit trail critical for compliance           | Ensure timestamps and comments are immutable              |

---

## Estimated Timeline

Assuming a **2-week sprint** cycle with a small team (2-3 developers):

| Sprint   | Duration | Stories        | Cumulative Progress |
|----------|----------|----------------|---------------------|
| Sprint 1 | Weeks 1-2  | US-013 to US-015 | 20% complete        |
| Sprint 2 | Weeks 3-4  | US-001 to US-005 | 53% complete        |
| Sprint 3 | Weeks 5-6  | US-004, US-007, US-009, US-010 | 80% complete (MVP) |
| Sprint 4 | Weeks 7-8  | US-011, US-012, US-006, US-008 | 100% complete       |

**Total Estimated Time: 8 weeks (4 sprints)**

**MVP Delivery: 6 weeks (end of Sprint 3)**

---

## Notes for Product Manager

### When to Release

**Option 1: MVP Release (End of Sprint 3)**
- Delivers core functionality
- Users can submit and approve expenses
- No filtering, but functional

**Option 2: Full Release (End of Sprint 4)**
- Complete feature set
- Better user experience with filters
- Rejected expense workflow complete

**Recommendation:** Release MVP at end of Sprint 3 for early feedback, then enhance in Sprint 4 based on user input.

### Stakeholder Communication

- **After Sprint 1**: Demo user registration and login
- **After Sprint 2**: Demo expense creation and viewing
- **After Sprint 3**:  Demo full approval workflow (MVP milestone)
- **After Sprint 4**: Demo filtering and audit trail (full release)

---

## Quick Reference:  Story Groupings

### User Management (Foundation)
- US-013, US-014, US-015

### Employee Core Features
- US-001, US-002, US-003, US-005

### Manager Core Features
- US-007, US-009, US-010

### Workflow Completion
- US-004 (bridges employee and manager workflows)

### Enhancements
- US-006, US-008, US-011, US-012

---

## Document Version

- **Version**:  1.0
- **Last Updated**: 2026-01-01
- **Status**: Ready for Development

---