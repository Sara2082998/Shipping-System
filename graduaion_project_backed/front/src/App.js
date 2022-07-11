import './App.css';
import {
  Routes,
  Route,
} from "react-router-dom";
import ShowCities from './components/cities/ShowCities';
import AddCity from './components/cities/addCity';
import AddStatus from './components/Status/AddStatus';
import ShowBranches from './components/Branches/ShowBranches';

function App() {
  console.log(process.env.base)
  return (
    <div className="App">
      <Routes>
        <Route path="/cities" element= {<ShowCities/>}></Route>
        <Route path="/addCity" element= {<AddCity/>}></Route>
        <Route path="/AddStatus" element= {<AddStatus/>}></Route>
        <Route path="/branches" element= {<ShowBranches/>}></Route>
      </Routes>
    </div>
  );
}

export default App;
