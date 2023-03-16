import { atom } from "jotai";
import { atomWithStorage } from 'jotai/utils'

const state = {
    userData: atom({})
};

export const searchFilter = atom('');

    userData : atomWithStorage('userData', {})
}
export default state;
