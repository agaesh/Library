<template>
    <nav class="nav-bar">
            <div class="sidebar-wrapper">
                <Sidebar />
            </div>
          
            <div class="brand">
                <h3>LIBRA</h3>
            </div>
       
        <ul class="nav-items">
            <li v-for="item in navItems"
                :key="item"
                class="nav-item"
                :class="{ active: activeItem === item }"
                @click="setActive(item)">
                {{ item }} 
            </li>
        </ul>
    </nav>
</template>

<script setup>
    import { ref } from 'vue'
    import Sidebar from '../components/Sidebar.vue'

    const navItems = ['Dashboard', 'Books', 'Add Book', 'Members', 'Settings']
    const activeItem = ref('Dashboard')

    function setActive(item) {
        activeItem.value = item
    }
</script>

<style scoped>
    .sidebar-wrapper{
        width:fit-content;
    }
    .nav-bar {
        display: flex;
        align-items: center;
        background-color: #ffffff;
        padding: 12px 24px;
        box-shadow: 0 2px 8px rgba(0, 0, 0, 0.05);
        border-radius: 12px;
        gap: 24px;
    }

    .brand {
        display: flex; /* align logo + text if needed */
        align-items: center;
        font-weight: 700;
        font-size: 18px;
        color: #1d4ed8; /* brand blue */
        white-space: nowrap; /* prevent wrapping */
        background: none; /* remove background */
        border: none; /* no border */
        padding: 0; /* no extra spacing */
        margin: 0;
    }
    
    .nav-items {
        list-style: none;
        display: flex;
        gap: 12px;
        margin: 0;
        padding: 0; 
        overflow:hidden;
    }

    .nav-item {
        padding: 8px 20px;
        border-radius: 999px;
        cursor: pointer;
        transition: all 0.2s ease;
        font-weight: 500;
        color: #6b7280;
        background-color: transparent;
        white-space: nowrap; /* prevent text wrapping inside pill */
        display:none;
    }

    .nav-item:hover {
        background-color: #e0f2ff;
    }

    .nav-item.active {
        background-color: #1d4ed8;
        color: #dbeafe;
        font-weight: 600;
        box-shadow: 0 2px 6px rgba(29, 78, 216, 0.3);
    }

     
    @media (min-width:800px){
        .nav-item{
            display:block;
        }
        .sidebar-wrapper{
            display:none; 
        }
        .nav-bar{
            margin:20px 0px;
        }
    }
</style>