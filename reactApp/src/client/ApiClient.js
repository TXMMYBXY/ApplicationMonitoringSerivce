const API_BASE_URL = import.meta.env.VITE_API_URL ?? 'http://localhost:5120';
console.log('API_BASE_URL =', API_BASE_URL);

export const statisticsApi = {
  async addStatistic(data) {
    const response = await fetch(`${API_BASE_URL}/api/statistics/add-statistic`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(data),
    });

    if (!response.ok) {
      alert(response.statusText);
      throw new Error('Failed to add statistic');
    }
  },

  async getAllStatistics() {
    const response = await fetch(`${API_BASE_URL}/api/statistics/get-all-statistics`);

    if (!response.ok) {
      throw new Error('Failed to fetch statistics');
    }

    return response.json();
  },

  async getStatisticsByDevice(deviceId) {
    const response = await fetch(`${API_BASE_URL}/api/statistics/${deviceId}/get-all-statistics-by-device`);

    if (!response.ok) {
      throw new Error('Failed to fetch statistics by device');
    }

    return response.json();
  },

  async getAllDevices() {
    const response = await fetch(`${API_BASE_URL}/api/statistics/get-all-devices`);

    if (!response.ok) {
      throw new Error('Failed to fetch devices');
    }

    return response.json();
  },

  async deleteStatistic(statisticId){
    const response = await fetch(`${API_BASE_URL}/api/statistics/delete-statistic`,{
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({id: statisticId}),
    })
    if (!response.ok) {
      throw new Error('Failed to add statistic');
    }
  }
};
