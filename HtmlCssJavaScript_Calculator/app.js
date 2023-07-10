const display = document.querySelector(".calculator-input");
const keys = document.querySelector(".calculator-keys");

let displayValue = "0";
let firstValue = null;
let waitingForSecondValue = false;
let operator = null;

function updateDisplay() {
    display.value = displayValue;
}

keys.addEventListener("click", function (e) {
    const element = e.target;
    const value = element.value;
    if (!element.matches("button")) return;
    switch (value) {
        case "+":
        case "-":
        case "*":
        case "/":
        case "=":
            handleOperator(value);
            break;
        case ".":
            inputDecimal();
            break;
        case "clear":
            clearDisplay();
            break;
        default:
            inputNumber(value);
            break;
    }
    updateDisplay();
});

function inputNumber(num) {
    if (waitingForSecondValue) {
        displayValue = num;
        waitingForSecondValue = false;
    } else {
        displayValue = displayValue == "0" ? num : displayValue + num;
    }
}

function handleOperator(nextOperator) {
    let value = parseFloat(displayValue);
    if (operator && waitingForSecondValue) {
        operator = nextOperator;
        return;
    }
    if (firstValue == null) {
        firstValue = value;
    } else {
        const result = calculate(firstValue, operator, value);
        displayValue = result.toString();
        firstValue = result;
    }
    operator = nextOperator;
    waitingForSecondValue = true;
}
function clearDisplay() {
    displayValue = "0";
    firstValue = null;
    waitingForSecondValue = false;
    operator = null;
}
function inputDecimal() {
    if (!displayValue.includes(".")) displayValue += ".";
}

function calculate(firstNumber, op, secondNumber) {
    switch (op) {
        case "+":
            return firstNumber + secondNumber;
        case "-":
            return firstNumber - secondNumber;
        case "*":
            return firstNumber * secondNumber;
        case "/":
            return firstNumber / secondNumber;
        default:
            return secondNumber;
    }
}






updateDisplay();