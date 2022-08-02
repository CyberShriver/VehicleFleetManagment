﻿
    < !--Styles -->
    <style>
        #chartdiv {
            width: 100%;
            height: 500px;
        }
    </style>

    <!--Resources -->
    <script src="https://localhost:44339/FleetApp/assets/js/Donut-Chart/index.js"></script>
    <script src="https://localhost:44339/FleetApp/assets/js/Donut-Chart/percent.js"></script>
    <script src="https://localhost:44339/FleetApp/assets/js/Donut-Chart/Animated.js"></script>

    <!--Chart code-- >
    <script>
        am5.ready(function () {

            // Create root element
            // https://www.amcharts.com/docs/v5/getting-started/#Root_element
            var root = am5.Root.new("chartdiv");


        // Set themes
        // https://www.amcharts.com/docs/v5/concepts/themes/
        root.setThemes([
        am5themes_Animated.new(root)
        ]);


        // Create chart
        // https://www.amcharts.com/docs/v5/charts/percent-charts/pie-chart/
        var chart = root.container.children.push(am5percent.PieChart.new(root, {
            layout: root.verticalLayout,
        innerRadius: am5.percent(50)
            }));


        // Create series
        // https://www.amcharts.com/docs/v5/charts/percent-charts/pie-chart/#Series
        var series = chart.series.push(am5percent.PieSeries.new(root, {
            valueField: "count",
        categoryField: "Start_Dte",
        alignLabels: false
            }));

        series.labels.template.setAll({
            textType: "circular",
        centerX: 0,
        centerY: 0
            });


        // Set data
        // https://www.amcharts.com/docs/v5/charts/percent-charts/pie-chart/#Setting_data
        series.data.setAll(<%= obj %>);


        // Create legend
        // https://www.amcharts.com/docs/v5/charts/percent-charts/legend-percent-series/
        var legend = chart.children.push(am5.Legend.new(root, {
            centerX: am5.percent(50),
        x: am5.percent(50),
        marginTop: 15,
        marginBottom: 15,
            }));

        legend.data.setAll(series.dataItems);


        // Play initial series animation
        // https://www.amcharts.com/docs/v5/concepts/animations/#Animation_of_series
        series.appear(1000, 100);

        }); // end am5.ready()
    </script>