d3.csv("resources/assets/sample.tsv", function(error, data) {
  // Variables
  let dataX = [];
  let dataY = [];
  let dataCategory = [];
  let dataDesc = [];

  // Parse variables
  data.forEach((element) => {
    dataX.push(element["Estimated"]);
    dataY.push(element["Actual"]);
    dataCategory.push(element["Category"]);
    dataDesc.push(element["Description"]);
  });

  // size and margins for the chart
  let margin = {top: 20, right: 30, bottom: 60, left: 40};
  let width = window.innerWidth - margin.left - margin.right - 8;
  let height = 500 - margin.top - margin.bottom;

  // x and y linear scales
  let x = d3.scale.linear()
            .domain([0, d3.max(dataX)])  // the range of the values to plot
            .range([ 0, width ]);        // the pixel range of the x-axis
  let y = d3.scale.linear()
            .domain([0, d3.max(dataY)])
            .range([ height, 0 ]);

  // the chart object, includes all margins
  var chart = d3.select("body")
  .append('svg:svg')
  .attr('width', width + margin.right + margin.left)
  .attr('height', height + margin.top + margin.bottom)
  .attr('class', 'chart')

  // the main object where the chart and axis will be drawn
  var main = chart.append('g')
  .attr('transform', 'translate(' + margin.left + ',' + margin.top + ')')
  .attr('width', width)
  .attr('height', height)
  .attr('class', 'main')   

  // draw the x axis
  var xAxis = d3.svg.axis()
  .scale(x)
  .orient('bottom');

  main.append('g')
  .attr('transform', 'translate(0,' + height + ')')
  .attr('class', 'main axis date')
  .call(xAxis);

  // draw the y axis
  var yAxis = d3.svg.axis()
  .scale(y)
  .orient('left');

  // Append
  main.append('g')
  .attr('transform', 'translate(0,0)')
  .attr('class', 'main axis date')
  .call(yAxis);

  // draw the graph object
  var g = main.append("svg:g"); 

  // add the tooltip area to the webpage
  var tooltip = d3.select("body").append("div")
      .attr("class", "tooltip")
      .style("opacity", 0);

  g.selectAll("scatter-dots")
    .data(dataY)  // using the values in the dataY array
    .enter().append("svg:circle")  // create a new circle for each value
        .attr("cy", function (d) { return y(d); } ) // translate y value to a pixel
        .attr("cx", function (d,i) { return x(dataX[i]); } ) // translate x value
        .attr("r", 4) // radius of circle
        .style("opacity", 0.6) // opacity of circle
        .on("mouseover", function(y, index) {
            tooltip.transition()
                 .duration(200)
                 .style("opacity", .9);
            tooltip.html(`<strong>${dataCategory[index]}</strong>
                  <br/>${dataDesc[index]}`)
                 .style("left", (d3.event.pageX + 5) + "px")
                 .style("top", (d3.event.pageY - 18) + "px");
        })
        .on("mouseout", function(d) {
            tooltip.transition()
                 .duration(500)
                 .style("opacity", 0);
        });

  chart.append('line')
      .attr('x1',x(10))
      .attr('x2',x(20))
      .attr('y1',y(5))
      .attr('y2',y(10))
      .attr('stroke-width', (x)=>{return 30;})
      .style('fill',"red")
});