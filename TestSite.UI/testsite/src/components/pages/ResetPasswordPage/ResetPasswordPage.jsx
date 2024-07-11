import React, { useState } from 'react';
import { useNavigate, useSearchParams } from 'react-router-dom';
import './ResetPasswordPage.css'; 

function ResetPasswordPage() {
  const [newPassword, setNewPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [error, setError] = useState('');
  const [message, setMessage] = useState('');
  const navigate = useNavigate();
  const [searchParams] = useSearchParams();
  const userId = searchParams.get('userId');
  const token = searchParams.get('token');

  const handleResetPassword = async () => {
    if (newPassword !== confirmPassword) {
      setError('Пароли не совпадают');
      return;
    }

    try {
      const response = await fetch('https://localhost:7136/api/Auth/PutResetPassword', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({ userId, token, newPassword }),
        mode: 'cors'
      });

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const data = await response.json();
      if (data.isSucceed) {
        setMessage('Пароль успешно изменен');
        setError('');
        setTimeout(() => {
          navigate('/login');
        }, 2000);
      } else {
        setError(data.error);
        setMessage('');
      }
    } catch (error) {
      console.error('Error during password reset:', error);
      setError('Failed to fetch');
      setMessage('');
    }
  };

  return (
    <div className="reset-password-container">
      <h2>Reset Password</h2>
      {message && <p className="message">{message}</p>}
      {error && <p className="error-message">{error}</p>}
      <input 
        type="password" 
        value={newPassword} 
        onChange={(e) => setNewPassword(e.target.value)} 
        placeholder="New Password" 
        className="input-field"
      />
      <input 
        type="password" 
        value={confirmPassword} 
        onChange={(e) => setConfirmPassword(e.target.value)} 
        placeholder="Confirm Password" 
        className="input-field"
      />
      <button onClick={handleResetPassword} className="button">Reset Password</button>
      <p className="back-to-login-link">
        <a href="/login">Вернуться к логину</a>
      </p>
    </div>
  );
}

export default ResetPasswordPage;
