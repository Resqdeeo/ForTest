import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import AvailableTests from './AvailableTests';
import './HomePage.css'; 

const HomePage = () => {
  const [username, setUsername] = useState('');
  const [activeButton, setActiveButton] = useState('availableTests');
  const [tests, setTests] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    fetchUser();
    if (activeButton === 'availableTests') {
      fetchAvailableTests();
    }
  }, [activeButton]);

  const fetchUser = async () => {
    try {
      const response = await fetch('https://localhost:7136/api/User/GetUser', {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'Accept': 'application/json',
          'Authorization': `Bearer ${localStorage.getItem('token')}` 
        }
      });

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const data = await response.json();
      setUsername(data.UserName);
    } catch (error) {
      console.error('Error fetching user:', error);
    }
  };

  const fetchAvailableTests = async () => {
    try {
      const response = await fetch('https://localhost:7136/api/Test/GetAvailableTest', {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'Accept': 'application/json',
          'Authorization': `Bearer ${localStorage.getItem('token')}` 
        }
      });

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const data = await response.json();
      setTests(data.Tests);
    } catch (error) {
      console.error('Error fetching available tests:', error);
    }
  };

  return (
    <div className="home-container">
      <div className="avatar-container">
        <div className="avatar"></div>
        <p className="welcome-message">Привет, {username}</p>
      </div>
      <div className="sidebar">
        <button
          className={`sidebar-button ${activeButton === 'availableTests' ? 'active' : ''}`}
          onClick={() => setActiveButton('availableTests')}
        >
          Доступные тесты
        </button>
        <button
          className={`sidebar-button ${activeButton === 'secondButton' ? 'active' : ''}`}
          onClick={() => setActiveButton('secondButton')}
        >
          Вторая кнопка
        </button>
        <button
          className={`sidebar-button ${activeButton === 'thirdButton' ? 'active' : ''}`}
          onClick={() => setActiveButton('thirdButton')}
        >
          Третья кнопка
        </button>
      </div>
      <div className="content">
        {activeButton === 'availableTests' && <AvailableTests tests={tests} />}
        {activeButton === 'secondButton' && <div>Контент второй кнопки</div>}
        {activeButton === 'thirdButton' && <div>Контент третьей кнопки</div>}
      </div>
    </div>
  );
};

export default HomePage;
