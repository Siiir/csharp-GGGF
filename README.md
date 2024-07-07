
# 🐇 **General GG Fibonacci (GGGF)** 🐇
**Generalized** **generator** of **gigantic** **Fibonacci** numbers.

## 🤔 **Want to know what the 1,000,000th Fibonacci number is?** 🤔
We've got you covered. Not that you can see it with your small eyes, but it makes an impression by overflowing your text buffer.

## 🧮 **Fibonacci with Negative Indices** 🧮
### **Interested in knowing Fibonacci numbers with a negative index, like -1,235,031?** 
Try our product! There actually exists a mathematical relation:

For every \( k \in \mathbb{Z} \), there exists such a function \( GFib(n) = F(n) \) for every \( n \in \mathbb{N} \), such that:
\[ GFib(k) = GFib(k+2) - GFib(k+1) \]
implying that:
\[ GFib(k+2) = GFib(k+1) + GFib(k) \]

## 🧩 **Usage** 🧩
```bash
dotnet run <Fibonacci index>
```
The Fibonacci index can be a positive or negative integer.

- **Positive indices** return the corresponding Fibonacci number.
- **Negative indices** return the corresponding negafibonacci number.

## 📝 **Notes:** 📝
1. **Negative Indexing:** Fibonacci numbers for negative indices follow the pattern:
    \[ F(-n) = (-1)^{(n+1)} 	imes F(n) \]
    This means:
    - \( F(-1) = 1 \)
    - \( F(-2) = -1 \)
    - \( F(-3) = 2 \)

2. **Large Numbers:** This implementation uses `BigInteger` to handle very large Fibonacci numbers. For example, Fibonacci(1,000,000) can be computed without overflow issues.

3. **Performance:** Matrix exponentiation is used for efficient computation, making it feasible to calculate Fibonacci numbers for very large indices quickly.

## 🚀 **Features** 🚀
- **Speed:** Efficient computation using matrix exponentiation.
- **Accuracy:** Handles very large numbers with `BigInteger`.
- **Flexibility:** Computes Fibonacci numbers for both positive and negative indices.

## 🤝 **Contributing** 🤝
Feel free to fork this project, submit issues, and make pull requests. For major changes, please open an issue first to discuss what you would like to change.

## 📄 **License** 📄
This project is licensed under the MIT License - see the LICENSE.md file for details.

## 💡 **Acknowledgments** 💡
- Inspired by the classical Fibonacci sequence and its mathematical beauty.

## 🧑‍💻 **Contact** 🧑‍💻
For any inquiries, please contact [tomasz_nehring@outlook.com](mailto:tomasz_nehring@outlook.com).
