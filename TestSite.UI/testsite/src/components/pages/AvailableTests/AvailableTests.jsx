import React from 'react';
import './AvailableTests.css'; // Импортируем CSS файл

const AvailableTests = ({ tests }) => {
  return (
    <div className="tests-container">
      {tests.map((test) => (
        <div key={test.Id} className="test-card">
          <h3>{test.Title}</h3>
        </div>
      ))}
    </div>
  );
};

export default AvailableTests;
