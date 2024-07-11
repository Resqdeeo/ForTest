import React from 'react';
import { useLocation } from 'react-router-dom';

const useQuery = () => {
    return new URLSearchParams(useLocation().search);
};

const EmailConfirmedPage = () => {
    const query = useQuery();
    const success = query.get('success') === 'true';
    const message = query.get('message');

    return (
        <div className="email-confirmed-container" style={styles.container}>
            {success ? (
                <h1 className="success-message" style={styles.successMessage}>Email successfully confirmed!</h1>
            ) : (
                <div className="error-message-container">
                    <h1 className="error-title" style={styles.errorMessage}>Email confirmation failed</h1>
                    {message && <p className="error-message">Error: {decodeURIComponent(message)}</p>}
                </div>
            )}
        </div>
    );
};

const styles = {
    container: {
        margin: '50px',
        padding: '20px',
        textAlign: 'center'
    },
    successMessage: {
        color: '#28a745'
    },
    errorMessage: {
        color: '#dc3545'
    }
};

export default EmailConfirmedPage;
