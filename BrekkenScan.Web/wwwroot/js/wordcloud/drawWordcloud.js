﻿function CreateWordcloudOf(consume) {
    var words = distinct(consume).map(function (product) {
        return {
            text: product,
            size: 30 + 50 * scale(consume.filter((e) => e === product).length)
        };
    });

    var layout = d3.layout.cloud()
        .size([900, 600])
        .words(words)
        .padding(5)
        .spiral("rectangular")
        .rotate(0)
        .font("Impact")
        .fontSize(function (d) { return d.size; })
        .on("end", draw);

    layout.start();

    function draw(words) {

        var color = d3.scale.linear()
            .domain([0, 2])
            .range(["#98afd4", "#6e9eea"]);

        d3.select("div .wordcloud").append("svg")
            .attr("width", layout.size()[0])
            .attr("height", layout.size()[1])
            .append("g")
            .attr("transform", "translate(" + layout.size()[0] / 2 + "," + layout.size()[1] / 2 + ")")
            .selectAll("text")
            .data(words)
            .enter().append("text")
            .style("font-size", function (d) { return d.size + "px"; })
            .style("fill", function (d, i) { return color(i % 3); })
            .style("font-family", "Impact")
            .attr("text-anchor", "middle")
            .attr("transform", function (d) {
                return "translate(" + [d.x, d.y] + ")rotate(" + d.rotate + ")";
            })
            .text(function (d) { return d.text; });
    }
}

function scale(num) {
    return 1 - Math.pow(2, -num);
}

function distinct(list) {
    return list.filter((x, i, a) => a.indexOf(x) === i);
}