import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './Register.css'; 

function Register() {
  const [login, setLogin] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const [message, setMessage] = useState('');
  const navigate = useNavigate();

  const handleRegister = async () => {
    try {
      const response = await fetch('https://localhost:7136/api/Auth/register', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({ login, email, password }),
        mode: 'cors'
      });

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const data = await response.json();
      if (data.success) {
        setMessage('Подтвердите почту');
        setError('');
        setTimeout(() => {
          navigate('/login');
        }, 20000); 
      } else {
        setError('Ошибка регистрации');
        setMessage('');
      }
    } catch (error) {
      console.error('Error during registration:', error);
      setError('Failed to fetch');
      setMessage('');
    }
  };

  return (
    <div className="register-container">
      <h2>Register</h2>
      {message && <p className="message">{message}</p>}
      {error && <p className="error-message">{error}</p>}
      <input 
        type="text" 
        value={login} 
        onChange={(e) => setLogin(e.target.value)} 
        placeholder="Login" 
        className="input-field"
      />
      <input 
        type="email" 
        value={email} 
        onChange={(e) => setEmail(e.target.value)} 
        placeholder="Email" 
        className="input-field"
      />
      <input 
        type="password" 
        value={password} 
        onChange={(e) => setPassword(e.target.value)} 
        placeholder="Password" 
        className="input-field"
      />
      <button onClick={handleRegister} className="button">Register</button>
      <p className="login-link">
        <a href="/login">Уже зарегистрированы?</a>
      </p>
    </div>
  );
}

export default Register;
