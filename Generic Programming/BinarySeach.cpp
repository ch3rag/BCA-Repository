// CHIRAG SINGH RAJPUT
// GENERIC BINARY SEARCH

#include <iostream>

    int IntCmp(void * vp1, void * vp2) {
        int i1 = * (int * ) vp1;
        int i2 = * (int * ) vp2;
        return i1 - i2;
    }
void * bSearch(void * key, void * base, int size, int elemsize, int( * cmpfn)(void * , void * )) {
    int lb = 0, ub = size - 1, mid;
    while (lb <= ub) {
        mid = (ub + lb) / 2;
        void * elem = (char * ) base + mid * elemsize;
        int cmp = (cmpfn(key, elem));
        if (cmp == 0) {
            return elem;
        } else if (cmp > 0) {
            lb = mid + 1;
        } else if (cmp < 0) {
            ub = mid - 1;
        }
    }
    return NULL;
}

int main() {
    int array[] = {1,2,3,4,5,6,7,8,9};
    
    int key = 9;
    int * found = (int * ) bSearch( & key, array, 9, sizeof(int), IntCmp);
    if (found == NULL) {
        std::cout << "NOT FOUND";
    } else {
        std::cout << "FOUND";
    }

}
