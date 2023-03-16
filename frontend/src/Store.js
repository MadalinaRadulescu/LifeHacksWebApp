import { atom } from "jotai";
import { atomWithStorage } from 'jotai/utils'

const state = {
    userData : atomWithStorage('userData', {})
};

export const searchFilter = atom('');

export default state;


