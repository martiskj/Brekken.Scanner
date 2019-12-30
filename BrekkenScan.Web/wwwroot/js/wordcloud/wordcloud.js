﻿function wordcloud(selector) {
    let width = 1200;
    let height = 650;

    var svg = d3
        .select(selector)
        .append('svg')
        .attr('width', width)
        .attr('height', height)
        .append('g')
        .attr('transform', 'translate(' + width / 2 + ', ' + height / 2 + ')');

    function draw(words) {
        var cloud = svg.selectAll('g text').data(words);

        var color = d3.scale.linear()
            .domain([0, 2])
            .range(["#98afd4", "#6e9eea"]);

         cloud.enter()
            .append("text")
            .style("font-family", "Impact")
            .style("fill", (d, i) => color(i % 3))
            .attr("text-anchor", "middle")
            .attr("font-size", 1)
            .text(d => d.text);

        cloud.transition()
            .duration(600)
            .style("font-size", d => d.size + "px")
            .attr("transform", d => "translate(" + [d.x, d.y] + ")rotate(" + d.rotate + ")")
            .style("fill-opacity", 1);

        cloud.exit()
            .transition()
            .duration(200)
            .style('fill-opacity', 1e-6)
            .attr('font-size', 1)
            .remove();
    }

    return {
        update: function (consume) {
            let words = distinct(consume).map(product => {
                return {
                    text: product,
                    size: consume.filter(c => c === product).length
                };
            });

            var wordscale = d3.scale.linear().range([30, 100]).domain([
                d3.min(words, d => d.size) - 1,
                d3.max(words, d => d.size)
            ]);

            d3.layout.cloud()
                .size([width, height])
                .words(words)
                .padding(5)
                .spiral("rectangular")
                .rotate(0)
                .font("Impact")
                .fontSize(d => wordscale(d.size))
                .on("end", draw)
                .start();
        }
    };
}

function distinct(list) {
    return list.filter((x, i, a) => a.indexOf(x) === i);
}
