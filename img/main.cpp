#include <iostream>
#include <limits>
#include <stdexcept>
#include <vector>

struct Room {
  int x; // left most
  int y; // bottom most
  int x_size;
  int y_size;

  std::vector<char> data;

  Room(int x, int y, int x_size, int y_size, char initial = '#')
      : x(x), y(y), x_size(x_size), y_size(y_size),
        data(x_size * y_size, initial) {}

  char &at(int x, int y) {
    if (x >= 0 && x < this->x_size && y >= 0 && y < this->y_size) {
      const int linear_index = y * this->x_size + x;
      return data[linear_index];
    }
    throw std::logic_error("Out of bounds");
  }

  void show() {
    for (int y_idx = y_size - 1; y_idx >= 0; --y_idx) {
      for (int x_idx = 0; x_idx < x_size; ++x_idx) {
        std::cout << at(x_idx, y_idx);
      }
      std::cout << std::endl;
    }
  }
};

std::ostream &operator<<(std::ostream &out, const Room &r) {
  return out << "[" << r.x << ", " << r.y << ", " << r.x_size << ", "
             << r.y_size << "]";
}

int main() {
  std::vector<Room> rooms;
  rooms.push_back(Room(0, 0, 6, 6, '*'));
  rooms.push_back(Room(6, 6, 6, 6, '&'));
  rooms.push_back(Room(12, 7, 6, 9, '+'));

  // find lower left and upper right corners
  int x_min = std::numeric_limits<int>::max();
  int y_min = std::numeric_limits<int>::max();
  int x_max = std::numeric_limits<int>::min();
  int y_max = std::numeric_limits<int>::min();

  for (auto &r : rooms) {
    if (r.x < x_min) {
      x_min = r.x;
    }
    if (r.y < y_min) {
      y_min = r.y;
    }
    if (r.x + r.x_size > x_max) {
      x_max = r.x + r.x_size;
    }
    if (r.y + r.y_size > y_max) {
      y_max = r.y + r.y_size;
    }
  }
  std::cout << "Input \n" << rooms[0] << "\n" << rooms[1] << std::endl;

  std::cout << "Bounding Box: " << x_min << ", " << y_min << ", "
            << x_max - x_min << ", " << y_max - y_min << std::endl;

  Room combined(x_min, y_min, x_max - x_min, y_max - y_min);
  // combined.show();

  for (auto &r : rooms) {
    for (int y_idx = 0; y_idx < r.y_size; ++y_idx) {
      for (int x_idx = 0; x_idx < r.x_size; ++x_idx) {
        const auto c = r.at(x_idx, y_idx);
        const int x_target = x_idx + r.x - combined.x;
        const int y_target = y_idx + r.y - combined.y;
        combined.at(x_target, y_target) = c;
      }
    }
  }
  combined.show();
}
