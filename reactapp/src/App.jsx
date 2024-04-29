import { BrowserRouter, Routes, Route } from 'react-router-dom'
import Home from './views/Home'
import Header from './components/sections/Header'
import Footer from './components/sections/Footer'
import "./assets/css/App.css";

function App() {

  return (
    <>
      <BrowserRouter>
        <div className='wrapper'>
          <Header />
          <main>
            <Routes>
              <Route path="/" element={<Home />} />
            </Routes>
          </main>
          <Footer />
        </div>
      </BrowserRouter>
    </>
  )
}

export default App
