# AI-Assisted Solo Development Experiment (with MCP)

## 1. Experiment Goal

**Goal:**
Evaluate where **AI assistance** reduce effort, improve quality, or add friction in a solo software project, broken down by roles (PM, Dev, QA, Reviewer).

This experiment is observational, not promotional.

---

## 2. Project Definition

### Selected Project: Expense Tracking & Approval System

A small internal system for submitting, reviewing, and approving employee expenses with clear lifecycle rules.

- **Project name:** Expense Tracker
- **Domain:** Expense submission & approval
- **Tech stack:**

  - Backend: ASP.NET Core (.NET), EF Core
  - Frontend: Angular
  - Database: Relational (PostgreSQL)

- **Estimated scope:** Medium

### Core Domain Concepts

- Expense
- User
- Approval / Decision
- Audit log

### Expense Lifecycle

- `Draft → Submitted → Approved / Rejected`

### Key Business Rules

- Draft expenses are editable
- Submitted expenses are read-only
- Approval and rejection require a comment
- Rejected expenses can be edited and resubmitted
- Approved expenses are immutable

### Success Criteria (binary)

- [ ] Core user flow implemented (submit → approve/reject)
- [ ] App builds, runs, and is deployable
- [ ] Backend enforces all business rules
- [ ] Frontend reflects state-driven behavior
- [ ] Tests cover critical domain logic

---

## 3. Initial Customer Specification (Customer Problem Description)

> Perspective: Customer requesting the system
> Purpose: Describe the **problem and expectations**, not solutions or technical design

---

### Who I am and what problem I have

I run a small-to-medium company where employees regularly spend money on behalf of the company — travel, meals, office supplies, software subscriptions, and similar expenses.

Right now, expense handling is **painful and inefficient**:

- People send receipts via email or chat
- Some use spreadsheets, some don’t
- Approvals are unclear and slow
- It’s hard to know what’s pending, approved, or already reimbursed
- We often lose context (why something was rejected, who approved it, when)

This causes:

- Frustration for employees
- Extra work for managers
- Errors and delays in reimbursements
- No clear audit trail

I want a **simple internal system** that helps us manage this process clearly and consistently.

---

### What I want the system to help me achieve

I want:

- Employees to **submit expenses in a structured way**
- Managers to **review and decide quickly**
- Everyone to always know the **current status** of an expense
- Clear rules so there is no confusion or arguing later
- A history of decisions (who approved or rejected, and why)

This system does **not** need to be fancy or complex.
It just needs to be **reliable, clear, and predictable**.

---

### How I imagine people using the system (High-Level)

#### Submitting expenses (Employee perspective)

- Employees record work-related expenses with basic information
- Expenses can be saved temporarily before submission
- Employees can fix mistakes or remove drafts before submitting
- Once submitted, expenses should not change automatically or accidentally

---

#### Reviewing expenses (Manager perspective)

- Managers see a clear list of expenses waiting for review
- Each expense includes enough context to make a decision
- Managers approve or reject expenses and explain their decision
- The system prevents invalid or duplicate actions

---

### Transparency and trust

For both employees and managers:

- It must always be clear what the current status of an expense is
- Decisions should show who made them, when, and why
- Rejected expenses should clearly explain what needs to be fixed
- Approved expenses should be final and protected from changes

---

### What I explicitly do NOT want

- Complex accounting features
- Bank or payment integrations
- Advanced reporting or analytics
- Mobile applications
- Overly flexible rules that cause inconsistent behavior

This is an **internal operational tool**, not a customer-facing product.

---

### What matters most to me

If I had to summarize, the system must be:

1. **Clear** – no ambiguity about what can be done and when
2. **Structured** – the same process for everyone
3. **Traceable** – decisions and comments are visible later
4. **Simple** – minimal features, minimal learning curve

If it achieves these things, it solves my problem.

---

## 4. Tools & Constraints (No MCP)

Tools & Tooling (No MCP)

At this stage of the experiment, **no MCP servers are used**.
All AI assistance is limited to **chat-based interaction** and **manual tool usage by the developer**.

The goal is to establish a **clean baseline** for AI usefulness _without_ tool-connected context.

| Purpose              | Tool                          | Notes                          |
| -------------------- | ----------------------------- | ------------------------------ |
| Source Control       | GitHub                        | Manual interaction only        |
| Backend Development  | ASP.NET Core (.NET), EF Core  | Local development              |
| Frontend Development | Angular                       | Local development              |
| Database             | PostgreSQL                    | Local instance                 |
| E2E Testing          | Playwright                    | Tests written and run manually |
| UI Components        | Angular Material (or similar) | No designer AI initially       |

> MCP-enabled tooling (e.g. repo access, test execution, task tracking) will be introduced later as a **separate showcase** to measure incremental impact.

---

## 5. Assistance Modes (Experimental Variables)

The project may use different assistance modes depending on the phase.

1. **No AI** – Manual work only (baseline where possible)
2. **AI (Chat-only)** – Reasoning, code generation, review

> MCP-based assistance will be evaluated later as a separate experiment.

---

## 6. AI Roles & Permissions

| Role        | Tool Access | Responsibilities                           | Constraints                |
| ----------- | ----------- | ------------------------------------------ | -------------------------- |
| PM AI       | Chat only   | Requirements clarification, task breakdown | No final decisions         |
| Dev AI      | Chat only   | Boilerplate, refactoring suggestions       | No direct code execution   |
| QA AI       | Chat only   | Test case suggestions, edge cases          | No correctness assumptions |
| Reviewer AI | Chat only   | Code review, smells, edge cases            | Advisory only              |
| Designer AI | Not used    | —                                          | —                          |

## 7. Standard Feature Execution Flow

Each feature must follow the same steps:

1. PM clarification
2. Human design decisions
3. Implementation
4. Testing
5. Review
6. Reflection & logging

---

## 8. Measurement Framework (Same for All Features)

### 8.1 Feature Metadata

- Feature name:
- Date:
- Assistance mode: No AI / Chat-only AI

---

### 8.2 Time Tracking (Estimates)

| Activity                  | Time |
| ------------------------- | ---- |
| Requirement clarification |
| Design                    |
| Coding                    |
| Debugging                 |
| Fixing AI output          |

---

### 8.3 AI Effectiveness (1–5)

| Question                   | Score |
| -------------------------- | ----- |
| AI saved time              |
| AI reduced thinking effort |
| AI caused rework           |
| AI output quality          |
| Overall usefulness         |

---

### 8.4 Quality Signals

- Bugs found during development:
- Bugs found after completion:
- Rewrites required later:
- Missed edge cases:

---

### 8.5 Friction Log

- Where AI helped most:
- Where AI slowed things down:
- Notable failures or hallucinations:

---

## 9. Final Evaluation (End of Project)

    1. Where did AI help most this week?
    2. Where did it clearly fail?
    3. Which role (PM / Dev / QA / Reviewer) was most valuable?
    4. What would I stop using AI for?

- Quality impact: Improved / Neutral / Worse
- Would I repeat this workflow? Yes / No
- Biggest insight from the experiment:

---

## 10. Mindset Reminder

This experiment measures **reduction of cognitive friction**, not replacement of engineering judgment.

Human remains accountable for all decisions.
