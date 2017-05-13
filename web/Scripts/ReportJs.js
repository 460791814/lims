//<!--报表控件-->
var chart;
function DataBangding(Xlable, data) {
    chart = new Highcharts.Chart({
        chart: {
            renderTo: 'container', //内容输入地址ID
            type: 'line',
            marginRight: 130,
            marginBottom: 60
        },
        title: {
            text: '',
            x: -20 //center
        },
        subtitle: {
            text: '',
            x: -20
        },
        xAxis: {
            min: 0,
            max: Xlable.length - 1,
            tickInterval: 1,
            categories: Xlable, // X坐标
            labels: {
                rotation: -45,
                align: 'right',
                style: {
                    fontSize: '13px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: ''
            },
            plotLines: [{//标准线
                value: 0, //线的Y轴坐标值
                width: 1, //线宽度
                color: '#808080'//标准线的颜色
            }]
        },
        tooltip: {//浮动提示框
            formatter: function () {
                return '<b>' + this.series.name + '</b><br/>' + //浮动提示
                        this.x + ': ' + this.y + ''; //浮动值提示
            }
        },
        legend: {//右侧对照栏，位置布局
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'top',
            x: -10,
            y: 100,
            borderWidth: 0//边框宽度
        },
        series: data
    });
}
