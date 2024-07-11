import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './Login.css'; // Импортируем CSS файл

function Login() {
  const [login, setLogin] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleLogin = async () => {
    try {
      const response = await fetch('https://localhost:7136/api/Auth/login', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Accept': 'application/json'
        },
        body: JSON.stringify({ login, password }),
        mode: 'cors'
      });

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const data = await response.json();
      if (data.success) {
        navigate('/home');
      } else {
        setError(data.message);
      }
    } catch (error) {
      console.error('Error during login:', error);
      setError('Failed to fetch');
    }
  };

  return (
    <div className="login-container">
      <h2>Login</h2>
      {error && <p className="error-message">{error}</p>}
      <input 
        type="text" 
        value={login} 
        onChange={(e) => setLogin(e.target.value)} 
        placeholder="Login" 
        className="input-field"
      />
      <input 
        type="password" 
        value={password} 
        onChange={(e) => setPassword(e.target.value)} 
        placeholder="Password" 
        className="input-field"
      />
      <p className="forgot-password-link">
        <a href="/forgot-password">Забыли пароль?</a>
      </p>
      <button onClick={handleLogin} className="button">Login</button>
      <p className="register-link">
        <a href="/register">Еще не зарегистрированы?</a>
      </p>
    </div>
  );
}

export default Login;
