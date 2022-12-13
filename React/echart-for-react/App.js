import ReactEChart from 'echarts-for-react';
import { useEffect, useState } from 'react';

const App = () => {
  const [dim, setDim] = useState({
    height: window.innerHeight,
    width: window.innerWidth,
  });

  useEffect(() => {
    const handleResize = () => {
      setDim({
        height: window.innerHeight,
        width: window.innerWidth,
      });
    };
    window.addEventListener('resize', handleResize);
  });

  let option = {
    xAxis: {
      type: 'category',
      data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
    },
    yAxis: {
      type: 'value',
    },
    series: [
      {
        data: [150, 230, 224, 218, 135, 147, 260],
        type: 'line',
      },
    ],
  };

  // const style = {
  //   backgroundColor: "#ffd166",
  //   resize: "both",
  //   overflow: "auto"
  // };

  return (
    <div className='App' id='App'>
      <h1>
        Dimension: {`${dim.height}`} x {`${dim.width}`}
      </h1>
      <ReactEChart
        option={option}
        opts={{
          renderer: 'canvas',
          height: `${dim.height}`,
          width: `${dim.width}`,
        }}
      />
    </div>
  );
};

export default App;
