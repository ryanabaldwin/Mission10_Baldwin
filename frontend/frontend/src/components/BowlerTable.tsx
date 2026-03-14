import { useEffect, useState } from 'react';
import type { Bowler } from '../types/Bowler';

const API_URL =
  import.meta.env.VITE_API_URL ?? 'http://localhost:5145/api/bowlers';

function formatName(bowler: Bowler) {
  return [
    bowler.bowlerFirstName,
    bowler.bowlerMiddleInit,
    bowler.bowlerLastName,
  ]
    .filter((part) => part && part.trim().length > 0)
    .join(' ');
}

function BowlerTable() {
  const [bowlers, setBowlers] = useState<Bowler[]>([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {
    const fetchBowlers = async () => {
      try {
        const response = await fetch(API_URL);

        if (!response.ok) {
          throw new Error('Unable to load bowlers from the API.');
        }

        const data: Bowler[] = await response.json();
        setBowlers(data);
      } catch (err) {
        if (err instanceof Error) {
          setError(err.message);
        } else {
          setError('An unexpected error occurred while loading bowlers.');
        }
      } finally {
        setIsLoading(false);
      }
    };

    fetchBowlers();
  }, []);

  if (isLoading) {
    return <p className="status-message">Loading bowlers...</p>;
  }

  if (error) {
    return <p className="status-message error">{error}</p>;
  }

  return (
    <div className="table-wrapper">
      <table>
        <thead>
          <tr>
            <th>Bowler Name</th>
            <th>Team Name</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone Number</th>
          </tr>
        </thead>
        <tbody>
          {bowlers.map((bowler) => (
            <tr
              key={`${bowler.bowlerFirstName}-${bowler.bowlerLastName}-${bowler.bowlerPhoneNumber}`}
            >
              <td>{formatName(bowler)}</td>
              <td>{bowler.teamName}</td>
              <td>{bowler.bowlerAddress ?? ''}</td>
              <td>{bowler.bowlerCity ?? ''}</td>
              <td>{bowler.bowlerState ?? ''}</td>
              <td>{bowler.bowlerZip ?? ''}</td>
              <td>{bowler.bowlerPhoneNumber ?? ''}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default BowlerTable;
