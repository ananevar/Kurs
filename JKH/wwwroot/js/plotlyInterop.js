window.plotlyInterop = {
  render: (divId, data, layout) => Plotly.newPlot(divId, data, layout, { responsive: true }),
  update: (divId, data, layout) => Plotly.react(divId, data, layout, { responsive: true })
};
