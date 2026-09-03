# CS13_NFA


- **States ($Q$):** $\\{ q_0, q_1, q_2, q_3, q_4 \\}$
- **Alphabet ($\\Sigma$):** $\\{ a, *, / \\}$
- **Start State ($q_0$):** $q_0$
- **Accept / Final State ($F$):** $\\{ q_4 \\}$

---

## Transition Table

| $\delta$ | $/$ | $*$ | $a$ |
| :---: | :---: | :---: | :---: |
| $\rightarrow q_0$ | $\{q_1\}$ | $\emptyset$ | $\emptyset$ |
| $q_1$ | $\emptyset$ | $\{q_2\}$ | $\emptyset$ |
| $q_2$ | $\{q_2\}$ | $\{q_3\}$ | $\{q_2\}$ |
| $q_3$ | $\{q_4\}$ | $\{q_3\}$ | $\{q_2\}$ |
| $*q_4$ | $\emptyset$ | $\emptyset$ | $\emptyset$ |

---

## Formal Transition Functions

$$\begin{aligned}
\delta(q_0, /) &= \{q_1\} & \delta(q_2, /) &= \{q_2\} & \delta(q_4, /) &= \emptyset \\
\delta(q_0, *) &= \emptyset & \delta(q_2, *) &= \{q_3\} & \delta(q_4, *) &= \emptyset \\
\delta(q_0, a) &= \emptyset & \delta(q_2, a) &= \{q_2\} & \delta(q_4, j) &= \emptyset \\
\\
\delta(q_1, /) &= \emptyset & \delta(q_3, /) &= \{q_4\} \\
\delta(q_1, *) &= \{q_2\} & \delta(q_3, *) &= \{q_3\} \\
\delta(q_1, a) &= \{q_0\} & \delta(q_3, a) &= \{q_2\}
\end{aligned}$$

---

## Transition Details

