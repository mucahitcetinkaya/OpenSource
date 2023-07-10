const clock = document.querySelector(".clock");

function tick() {
    const time = new Date();
    let hour = time.getHours();
    let minute = time.getMinutes();
    let second = time.getSeconds();

    const html = `<span>${hour}</span>:<span>${minute}</span>:<span>${second}</span>`;
    clock.innerHTML = html;
}

setInterval(tick, 1000);