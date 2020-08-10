import { Wordcloud } from './wordcloud/wordcloud.js';

window.onload = async function () {
    let wc = new Wordcloud('div .wordcloud');

    let consumeTotal = await fetchTotalConsume();
    showConsumeTotal(consumeTotal);

    let consumeTonight = await fetchTonightsConsume();
    showConsumeTonight(consumeTonight);
    updateWordcloud(wc, consumeTonight);

    var form = document.getElementById('form-consume');
    form.addEventListener('submit', async event => {
        event.preventDefault();

        await postConsume(form);
        form.reset();

        let consumeTotal = await fetchTotalConsume();
        let consumeTonight = await fetchTonightsConsume();

        showConsumeTotal(consumeTotal);
        showConsumeTonight(consumeTonight);

        updateWordcloud(wc, consumeTonight);
    });

    document.getElementById("barcode-input").focus();
};

function showConsumeTonight(consume) {
    var tonight = document.getElementsByClassName('boks-liten-tall')[1];
    tonight.classList.remove('loading');
    tonight.innerHTML = consume.total;
}

function showConsumeTotal(consume) {
    var tonight = document.getElementsByClassName('boks-liten-tall')[0];
    tonight.classList.remove('loading');
    tonight.innerHTML = consume.total;
}

function updateWordcloud(wc, consume) {
    wc.update(consume.result.map(c => c.product));
}

async function postConsume(form) {
    let request = createRequestFromForm(form);

    var response = await fetch('/api/consume', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(request)
    });

    return response;
}

function createRequestFromForm(form) {
    let request = {};
    for (let i = 0; i < form.length - 1; i++) {
        request[form[i].name] = form[i].value;
    }

    return request;
}

async function fetchTonightsConsume() {
    let date = hoursAgo(13).toISOString();
    console.log(date);

    let response = await fetch(`api/consume?from=${date}`);
    return await response.json();
}

async function fetchTotalConsume() {
    let response = await fetch(`api/consume`);
    return await response.json();
}

function hoursAgo(hours) {
    return new Date(Date.now() - 1000 * 3600 * hours);
}