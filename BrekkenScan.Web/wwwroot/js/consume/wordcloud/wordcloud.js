export class Wordcloud {

    constructor(selector) {
        this.width = 1200;
        this.height = 650;
        this.svg = d3
            .select(selector)
            .append('svg')
            .attr('width', this.width)
            .attr('height', this.height)
            .append('g')
            .attr('transform', 'translate(' + this.width / 2 + ', ' + this.height / 2 + ')');
    }

    update(consume) {
        let words = this._distinct(consume).map(product => {
            return {
                text: product,
                size: consume.filter(c => c === product).length
            };
        });

        let wordscale = d3.scale.linear().range([30, 100]).domain([
            d3.min(words, d => d.size) - 1,
            d3.max(words, d => d.size)
        ]);

        d3.layout.cloud()
            .size([this.width, this.height])
            .words(words)
            .padding(5)
            .spiral("archimedean")
            .rotate(0)
            .font("Impact")
            .fontSize(d => wordscale(d.size))
            .on("end", d => this._draw(d, this.svg))
            .start();
    }

    _draw(words, canvas) {
        let cloud = canvas.selectAll('g text').data(words, d => d.text);

        let color = d3.scale.linear()
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

    _distinct(list) {
        return list.filter((x, i, a) => a.indexOf(x) === i);
    }
}